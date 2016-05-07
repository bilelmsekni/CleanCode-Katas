using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using NUnit.Framework;

namespace NamingAndCommenting
{   
    [TestFixture]
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void should_return_0_discount_when_no_product_is_bought()
        {
            var discount = calculator.Calc(0, 10);
            discount.Should().Be(0);
        }

        [Test]
        public void should_return_0_discount_when_one_product_with_price_5d_is_bought()
        {
            var discount = calculator.Calc(1, 5d);
            discount.Should().Be(0);
        }

        [Test]
        public void should_return_10d_discount_when_6_products_with_price_5d_are_bought()
        {
            var discount = calculator.Calc(6, 5d);
            discount.Should().Be(10d);
        }

        [Test]
        public void should_return_5d_discount_when_5_products_with_price_5d_are_bought()
        {
            var discount = calculator.Calc(5, 5d);
            discount.Should().Be(5d);
        }

        [Test]
        public void should_return_30d_discount_when_12_products_with_price_5d_are_bought()
        {
            var discount = calculator.Calc(12, 5d);
            discount.Should().Be(30d);
        }
    }
}
