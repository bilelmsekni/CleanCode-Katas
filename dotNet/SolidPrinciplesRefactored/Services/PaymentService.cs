using SolidPrinciplesRefactored.Model;
using SolidPrinciplesRefactored.Utilities;
using SolidPrinciplesRefactored.Utilities.Exceptions;

namespace SolidPrinciplesRefactored.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentProcessor paymentProcessor;

        public PaymentService(IPaymentProcessor processor)
        {
            paymentProcessor = processor;
        }

        public void Charge(PaymentDetails paymentDetails, double totalAmount)
        {
            if (paymentDetails.PaymentMethod == PaymentMethod.ContactCreditCard)
            {
                paymentProcessor.ChargeCard(paymentDetails, totalAmount);
            }
            else if (paymentDetails.PaymentMethod == PaymentMethod.ContactLessCreditCard)
            {
                AuthorizePayment(totalAmount);
                paymentProcessor.ChargeCard(paymentDetails, totalAmount);
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

    }
}
