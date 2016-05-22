using System.Collections.Generic;
using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services
{
    public interface ICalculatorService
    {
        double CalculateOrderAmount(IEnumerable<OrderItem> items);
    }
}