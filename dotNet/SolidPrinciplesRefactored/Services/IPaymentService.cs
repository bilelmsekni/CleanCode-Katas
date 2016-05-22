using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services
{
    public interface IPaymentService
    {
        void Charge(PaymentDetails paymentDetails, double totalAmount);
    }
}