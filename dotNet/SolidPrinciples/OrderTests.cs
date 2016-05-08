using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SolidPrinciples.Model;
using Ploeh.AutoFixture;

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
        public void Should_execute_order_when_cart_is_ready()
        {
            var fakeCart = fixture.Build<Cart>().Create();
            var fakePaymentDetails = fixture.Create<PaymentDetails>();
            var fakePrintReceipt = true;

            var order = new Order();
            order.ExecuteOrder(fakeCart, fakePaymentDetails, fakePrintReceipt);


        }
    }
}
