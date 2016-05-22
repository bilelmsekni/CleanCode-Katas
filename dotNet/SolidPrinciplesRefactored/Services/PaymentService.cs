using SolidPrinciplesRefactored.Model;
using SolidPrinciplesRefactored.Utilities;
using SolidPrinciplesRefactored.Utilities.Exceptions;

namespace SolidPrinciplesRefactored.Services
{
    public class PaymentService : IPaymentService
    {
        public void Charge(PaymentDetails paymentDetails, double totalAmount)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.ContactCreditCard)
            {
                ChargeCard(paymentDetails, totalAmount);
            }
            else if (paymentDetails.PaymentMethod == PaymentMethod.ContactLessCreditCard)
            {
                AuthorizePayment(totalAmount);
                ChargeCard(paymentDetails, totalAmount);
            }
            else
            {
                throw new NotValidPaymentException("Can not charge customer");
            }
        }

        private void AuthorizePayment(double totalAmount)
        {
            if (totalAmount > 20) throw new UnAuthorizedContactLessPayment("Amount is too big");
            Logger.Info(string.Format("Payment for {0} has been authorized", totalAmount));
        }

        private void ChargeCard(PaymentDetails paymentDetails, double totalAmount)
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
