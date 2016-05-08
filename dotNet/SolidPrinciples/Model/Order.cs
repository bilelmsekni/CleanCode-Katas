using System;
using SolidPrinciples.Hardware.Api;
using SolidPrinciples.Services;
using SolidPrinciples.Utilities;
using SolidPrinciples.Utilities.Exceptions;

namespace SolidPrinciples.Model
{
    public class Order
    {
        readonly IPrinter printer;

        public Order()
        {
            printer = new HpPrinter();
        }

        public void ExecuteOrder(Cart cart, PaymentDetails paymentDetails, bool printReceipt)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.CreditCard)
            {
                ChargeCard(paymentDetails, cart);
            }

            ReserveInventory(cart);

            if (printReceipt)
            {
                PrintReceipt(cart);
            }
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

        private void ReserveInventory(Cart cart)
        {
            foreach (var item in cart.Items)
            {
                try
                {
                    var inventoryService = new InventoryService();
                    inventoryService.Reserve(item.ItemId, item.Quantity);

                }
                catch (InsufficientInventoryException ex)
                {
                    throw new OrderException("Insufficient inventory for item " + item.ItemId, ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("Problem reserving inventory", ex);
                }
            }
        }

        private void ChargeCard(PaymentDetails paymentDetails, Cart cart)
        {
            using (var paymentService = new PaymentService())
            {
                try
                {
                    paymentService.Credentials = paymentDetails.Credentials;
                    paymentService.CardNumber = paymentDetails.CreditCardNumber;
                    paymentService.ExpiresMonth = paymentDetails.ExpiresMonth;
                    paymentService.ExpiresYear = paymentDetails.ExpiresYear;
                    paymentService.NameOnCard = paymentDetails.CardholderName;
                    paymentService.AmountToCharge = cart.TotalAmount;

                    paymentService.Charge();
                }
                catch (RejectedCardException ex)
                {
                    throw new OrderException("The card gateway rejected the card.", ex);
                }
                catch (Exception ex)
                {
                    throw new OrderException("There was a problem with your card.", ex);
                }
            }
        }
    }
}
