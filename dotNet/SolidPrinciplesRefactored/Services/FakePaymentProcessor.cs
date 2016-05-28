using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services
{
    public class FakePaymentProcessor : IPaymentProcessor
    {
        public void ChargeCard(PaymentDetails paymentDetails, double totalAmount)
        {
            //Don't worry, i have your money in a safe place
        }
    }
}