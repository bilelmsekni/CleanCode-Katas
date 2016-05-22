using System.Collections.Generic;
using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services
{
    public class CalculatorService : ICalculatorService
    {
        public double CalculateOrderAmount(List<OrderItem> items)
        {
            var total = 0d;
            foreach (var item in items)
            {
                total += item.Price * item.Quantity - item.Discount;
            }
            return total;
        }
    }
}
