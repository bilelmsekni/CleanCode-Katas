using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services.CalculationRules
{
    public class DrinkRule : ICalculationRule
    {
        public bool IsMatch(string itemId)
        {
            return itemId == "Drink";
        }

        public double Apply(OrderItem item)
        {
            var setsOfThree = item.Quantity / 3;
            return (item.Quantity - setsOfThree) * item.Price;
        }
    }
}
