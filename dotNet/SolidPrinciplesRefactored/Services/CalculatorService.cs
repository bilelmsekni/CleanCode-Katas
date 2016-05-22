using System.Collections.Generic;
using System.Linq;
using SolidPrinciplesRefactored.Model;
using SolidPrinciplesRefactored.Services.CalculationRules;

namespace SolidPrinciplesRefactored.Services
{
    public class CalculatorService : ICalculatorService
    {
        private List<ICalculationRule> calculationRules = new List<ICalculationRule>
        {
            new BurgerRule(),
            new DrinkRule(),
            new MenuRule()
        };

        public double CalculateOrderAmount(IEnumerable<OrderItem> items)
        {
            var total = 0d;
            foreach (var item in items)
            {
                var rule = calculationRules.FirstOrDefault(r => r.IsMatch(item.ItemId));
                if (rule != null)
                {
                    total += rule.Apply(item);
                }
            }
            return total;
        }
    }
}
