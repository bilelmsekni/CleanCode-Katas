using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;
using SolidPrinciples.Model;
using Ploeh.AutoFixture;
using SolidPrinciples.Utilities.Exceptions;

namespace SolidPrinciples
{
    [TestFixture]
    public class OrderTests
    {
        private Fixture fixture;

        [SetUp]
        public void SetUp()
        {
            fixture = new Fixture();
        }

        [Test]
        public void Should_execute_order_when_cart_is_ready_and_payment_is_with_contact_and_print_receipt()
        {
            var fakeCart = fixture.Build<Cart>().Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c=>c.PaymentMethod, PaymentMethod.ContactCreditCard)                
                .Create();
            var fakePrintReceipt = true;

            var order = new Order();
            order.ExecuteOrder(fakeCart, fakePaymentDetails, fakePrintReceipt);                        
        }

        [Test]
        public void Should_execute_order_when_cart_is_ready_and_payment_is_with_contactless_and_print_receipt()
        {
            var fakeCart = fixture.Build<Cart>()
                .With(c=>c.TotalAmount, 19)
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactLessCreditCard)
                .Create();
            var fakePrintReceipt = true;

            var order = new Order();
            order.ExecuteOrder(fakeCart, fakePaymentDetails, fakePrintReceipt);
        }

        [Test]
        public void Should_throw_exception_when_order_amount_is_29_and_payment_is_with_contactless()
        {
            var fakeCart = fixture.Build<Cart>()
                .With(c => c.TotalAmount, 29)
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.ContactLessCreditCard)
                .Create();
            var fakePrintReceipt = true;

            var order = new Order();
            order.Invoking(y => y.ExecuteOrder(fakeCart, fakePaymentDetails, fakePrintReceipt))
                .ShouldThrow<UnAuthorizedContactLessPayment>()
                .WithMessage("Amount is too big");           
        }

        [Test]
        public void Should_throw_NotValidPaymentException_when_payement_Method_is_mobile()
        {
            var fakeCart = fixture.Build<Cart>()
                .With(c => c.TotalAmount, 10)
                .Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .With(c => c.PaymentMethod, PaymentMethod.Mobile)
                .Create();
            var fakePrintReceipt = true;

            var order = new Order();
            order.Invoking(y => y.ExecuteOrder(fakeCart, fakePaymentDetails, fakePrintReceipt))
                .ShouldThrow<NotValidPaymentException>()
                .WithMessage("Can not charge customer");
        }

        [Test]
        public void Should_execute_order_when_cart_is_ready_but_without_print_receipt()
        {
            var fakeCart = fixture.Build<Cart>().Create();
            var fakePaymentDetails = fixture.Build<PaymentDetails>()
                .Create();
            var fakePrintReceipt = false;

            var order = new Order();
            order.ExecuteOrder(fakeCart, fakePaymentDetails, fakePrintReceipt);
        }
    }
}
