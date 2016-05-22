using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services.CalculationRules
{
    public class MenuRule : ICalculationRule
    {
        public bool IsMatch(string itemId)
        {
            return itemId == "Menu";
        }

        public double Apply(OrderItem item)
        {
            return item.Price * item.Quantity * 0.9;
        }
    }
}
