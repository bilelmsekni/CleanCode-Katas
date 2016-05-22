using NUnit.Framework;
using Ploeh.AutoFixture;
using SolidPrinciplesRefactored.Model;
using SolidPrinciplesRefactored.Services;

namespace SolidPrinciplesRefactored
{
    [TestFixture]
    public class RestaurantTests
    {
        private Fixture fixture;
        private Restaurant restaurant;
        private ICalculatorService calculatorService;
        private IPaymentService paymentService;
        private ICookingService cookingService;
        private IPrintService printService;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            calculatorService = new CalculatorService();
            paymentService = new PaymentService();
            cookingService = new CookingService();
            printService = new PrintService(); 
            restaurant = new Restaurant(calculatorService, paymentService, cookingService, printService);
        }

        [Test]
        public void Should_execute_order_when_payment_is_with_contact_and_print_receipt()
        {
            var order = fixture.Build<Order>().Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactCreditCard)
                .Create();
            var fakePrintReceipt = true;

            restaurant.ExecuteOrder(order, fakePaymentDetails, fakePrintReceipt);
        }
    }
}
