using System;
using SolidPrinciples.Hardware.Api;
using SolidPrinciples.Services;
using SolidPrinciples.Utilities;
using SolidPrinciples.Utilities.Exceptions;

namespace SolidPrinciples.Model
{
    public class Order
    {
        readonly HpPrinter printer;

        public Order()
        {
            printer = new HpPrinter();
        }

        public void ExecuteOrder(Cart cart, PaymentDetails paymentDetails, bool printReceipt)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.ContactCreditCard)
            {
                ChargeCard(paymentDetails, cart);
            }
            else if (paymentDetails.PaymentMethod == PaymentMethod.ContactLessCreditCard)
            {
                AuthorizePayement(cart.TotalAmount);
                ChargeCard(paymentDetails, cart);
            }
            else
            {
                throw new NotValidPaymentException("Can not charge customer");
            }

            ReserveCartItems(cart);

            if (printReceipt)
            {
                PrintReceipt(cart);
            }
        }

        private void AuthorizePayement(double purchaseAmount)
        {
            if (purchaseAmount > 20) throw new UnAuthorizedContactLessPayment("Amount is too big");
            Logger.Info(string.Format("Payement for {0} has been authorized", purchaseAmount));
        }

        private void PrintReceipt(Cart cart)
        {
            string customerEmail = cart.CustomerEmail;
            if (!string.IsNullOrEmpty(customerEmail))
            {
                var receipt = new Receipt
                {
                    Title = "Receipt for your order placed on " + DateTime.Now,
                    Body = "Your order details: \n "
                };
                foreach (var orderItem in cart.Items)
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

        private void ReserveCartItems(Cart cart)
        {
            var inventory = new Inventory();
            foreach (var item in cart.Items)
            {
                try
                {
                    inventory.Reserve(item.ItemId, item.Quantity);
                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.ItemId, ex);
                }
            }
        }

        private void ChargeCard(PaymentDetails paymentDetails, Cart cart)
        {
            using (var ccMachine = new CreditCardMachine())
            {
                try
                {                    
                    ccMachine.CardNumber = paymentDetails.CreditCardNumber;
                    ccMachine.ExpiresMonth = paymentDetails.ExpiresMonth;
                    ccMachine.ExpiresYear = paymentDetails.ExpiresYear;
                    ccMachine.NameOnCard = paymentDetails.CardholderName;
                    ccMachine.AmountToCharge = cart.TotalAmount;

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
