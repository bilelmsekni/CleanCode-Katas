using System;
using SolidPrinciples.Hardware.Api;
using SolidPrinciples.Model;
using SolidPrinciples.Services;
using SolidPrinciples.Utilities;
using SolidPrinciples.Utilities.Exceptions;

namespace SolidPrinciples
{
    public class McBurgerRestaurant
    {
        readonly HpPrinter printer;

        public McBurgerRestaurant()
        {
            printer = new HpPrinter();
        }

        public void ExecuteOrder(Order order, PaymentDetails paymentDetails, bool printReceipt)
        {
            CalculateAmount(order);
            if (paymentDetails.PaymentMethod == PaymentMethod.ContactCreditCard)
            {
                ChargeCard(paymentDetails, order);
            }
            else if (paymentDetails.PaymentMethod == PaymentMethod.ContactLessCreditCard)
            {
                AuthorizePayment(order.TotalAmount);
                ChargeCard(paymentDetails, order);
            }
            else
            {
                throw new NotValidPaymentException("Can not charge customer");
            }

            PrepareOrder(order);

            if (printReceipt)
            {
                PrintReceipt(order);
            }
        }

        private void CalculateAmount(Order order)
        {
            var total = 0d;
            foreach (var item in order.Items)
            {
                if (item.ItemId == Constants.Drink)
                {
                    var setsOfThree = item.Quantity / 3;
                    total += (item.Quantity - setsOfThree) * item.Price;
                }
                else if (item.ItemId == Constants.CheeseBurger)
                {
                    total += item.Price * item.Quantity;
                }
                else if (item.ItemId == Constants.CheeseBurgerMenu)
                {
                    total += item.Price * item.Quantity * 0.9;
                }
            }
            order.TotalAmount = total;
        }

        private void AuthorizePayment(double purchaseAmount)
        {
            if (purchaseAmount > 20) throw new UnAuthorizedContactLessPayment("Amount is too big");
            Logger.Info(string.Format("Payment for {0} has been authorized", purchaseAmount));
        }

        private void PrintReceipt(Order order)
        {
            string customerEmail = order.CustomerEmail;
            if (!string.IsNullOrEmpty(customerEmail))
            {
                var receipt = new Receipt
                {
                    Title = "Receipt for your order placed on " + DateTime.Now,
                    Body = "Your order details: \n "
                };
                foreach (var orderItem in order.Items)
                {
                    receipt.Body += orderItem.Quantity + " of item " + orderItem.ItemId;
                }

                try
                {
                    printer.Print(receipt);
                }
                catch (Exception ex)
                {
                    Logger.Error("Problem sending notification email", ex);
                }

            }
        }

        private void PrepareOrder(Order order)
        {
            var cooker = new CookingService();
            foreach (var item in order.Items)
            {
                cooker.Prepare(item.ItemId, item.Quantity);
            }
        }

        private void ChargeCard(PaymentDetails paymentDetails, Order order)
        {
            using (var ccMachine = new CreditCardMachine())
            {
                try
                {
                    ccMachine.CardNumber = paymentDetails.CreditCardNumber;
                    ccMachine.ExpiresMonth = paymentDetails.ExpiresMonth;
                    ccMachine.ExpiresYear = paymentDetails.ExpiresYear;
                    ccMachine.NameOnCard = paymentDetails.CardholderName;
                    ccMachine.AmountToCharge = order.TotalAmount;

                    ccMachine.Charge();
                }
                catch (RejectedCardException ex)
                {
                    throw new OrderException("The card gateway rejected the card.", ex);
                }
            }
        }
    }
}
