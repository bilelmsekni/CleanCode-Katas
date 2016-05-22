using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services.CalculationRules
{
    public class BurgerRule : ICalculationRule
    {
        public bool IsMatch(string itemId)
        {
            return itemId == "Burger";
        }

        public double Apply(OrderItem item)
        {
            return item.Price * item.Quantity;
        }
    }
}
