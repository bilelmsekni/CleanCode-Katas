using SolidPrinciplesRefactored.Model;
using SolidPrinciplesRefactored.Utilities.Exceptions;

namespace SolidPrinciplesRefactored.Services
{
    public class PaymentProcessor : IPaymentProcessor
    {
        public void ChargeCard(PaymentDetails paymentDetails, double totalAmount)
        {
            using (var ccMachine = new CreditCardMachine())
            {
                try
                {
                    ccMachine.CardNumber = paymentDetails.CreditCardNumber;
                    ccMachine.ExpiresMonth = paymentDetails.ExpiresMonth;
                    ccMachine.ExpiresYear = paymentDetails.ExpiresYear;
                    ccMachine.NameOnCard = paymentDetails.CardholderName;
                    ccMachine.AmountToCharge = totalAmount;

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