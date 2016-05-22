using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services.CalculationRules
{
    public interface ICalculationRule
    {
        bool IsMatch(string itemId);
        double Apply(OrderItem item);
    }
}