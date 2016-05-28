using FluentAssertions;
using NUnit.Framework;
using Ploeh.AutoFixture;
using SolidPrinciplesRefactored.Model;
using SolidPrinciplesRefactored.Services;
using SolidPrinciplesRefactored.Utilities.Exceptions;

namespace SolidPrinciplesRefactored
{
    [TestFixture]
    public class McBurgerRestaurantTests
    {
        private Fixture fixture;
        private McBurgerRestaurant restaurant;
        private ICalculatorService calculatorService;
        private IPaymentService paymentService;
        private ICookingService cookingService;
        private IPrintService printService;
        private FakePaymentProcessor fakePaymentProcessor;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
            calculatorService = new CalculatorService();
            fakePaymentProcessor = new FakePaymentProcessor();
            paymentService = new PaymentService(fakePaymentProcessor);
            cookingService = new CookingService();
            printService = new PrintService();
            restaurant = new McBurgerRestaurant(calculatorService, paymentService, cookingService, printService);
        }

        [Test]
        public void Should_execute_order_when_payment_is_with_contact_and_print_receipt()
        {
            var orderItems = fixture.Build<OrderItem>()
                            .With(c => c.Quantity, 1)
                            .With(c => c.Price, 10)
                            .With(c => c.ItemId, Constants.CheeseBurgerMenu)
                            .CreateMany(1);
            var order = fixture.Build<Order>()
                .With(o => o.Items, orderItems)
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactCreditCard)
                .Create();
            var fakePrintReceipt = true;

            restaurant.ExecuteOrder(order, fakePaymentDetails, fakePrintReceipt);
        }

        [Test]
        public void Should_execute_order_when_order_is_3_drinks_and_payment_is_contactless_and_print_receipt()
        {
            var orderItems = fixture.Build<OrderItem>()
                .With(c => c.Quantity, 1)
                .With(c => c.Price, 5)
                .With(c => c.ItemId, "Drink")
                .CreateMany(3);
            var fakeOrder = fixture.Build<Order>()
                .With(c => c.Items, orderItems)
                .Create();

            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactLessCreditCard)
                .Create();
            var fakePrintReceipt = true;

            restaurant.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt);
        }

        [Test]
        public void Should_throw_exception_when_order_is_5_burgers_and_payment_is_with_contactless()
        {
            var orderItems = fixture.Build<OrderItem>()
                .With(c => c.Quantity, 5)
                .With(c => c.Price, 5)
                .With(c => c.ItemId, "Burger")
                .CreateMany(1);

            var fakeOrder = fixture.Build<Order>()
                .With(c => c.Items, orderItems)
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactLessCreditCard)
                .Create();

            var fakePrintReceipt = false;

            restaurant.Invoking(y => y.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt))
                .ShouldThrow<UnAuthorizedContactLessPayment>()
                .WithMessage("Amount is too big");
        }

        [Test]
        public void Should_throw_NotValidPaymentException_when_Payment_Method_is_mobile()
        {
            var fakeOrder = fixture.Build<Order>()
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.Mobile)
                .Create();
            var fakePrintReceipt = true;

            restaurant.Invoking(y => y.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt))
                .ShouldThrow<NotValidPaymentException>()
                .WithMessage("Can not charge customer");
        }

        [Test]
        public void Should_execute_order_when_Payment_with_contact_but_without_print_receipt()
        {
            var orderItems = fixture.Build<OrderItem>()
                            .With(c => c.Quantity, 1)
                            .With(c => c.Price, 10)
                            .With(c => c.ItemId, Constants.CheeseBurgerMenu)
                            .CreateMany(1);
            var fakeOrder = fixture.Build<Order>()
                .With(o => o.Items, orderItems)
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactCreditCard)
                .Create();
            var fakePrintReceipt = false;

            restaurant.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt);
        }

        [Test]
        public void Should_execute_order_when_order_is_1_menu_and_Payment_with_contactless_but_without_print_receipt()
        {
            var orderItems = fixture.Build<OrderItem>()
                .With(c => c.Quantity, 1)
                .With(c => c.Price, 10)
                .With(c => c.ItemId, Constants.CheeseBurgerMenu)
                .CreateMany(1);
            var fakeOrder = fixture.Build<Order>()
                .With(c => c.Items, orderItems)
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactLessCreditCard)
                .Create();
            var fakePrintReceipt = false;

            restaurant.ExecuteOrder(fakeOrder, fakePaymentDetails, fakePrintReceipt);
        }

        [Test]
        public void Should_authorize_payment_when_contactless_and_amout_is_19()
        {
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactLessCreditCard)
                .Create();
            paymentService.Invoking(x => x.Charge(fakePaymentDetails, 19)).ShouldNotThrow<UnAuthorizedContactLessPayment>();
        }
    }
}
