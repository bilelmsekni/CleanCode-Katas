using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services
{
    public interface IPaymentProcessor
    {
        void ChargeCard(PaymentDetails paymentDetails, double totalAmount);
    }
}