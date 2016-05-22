using SolidPrinciplesRefactored.Model;

namespace SolidPrinciplesRefactored.Services
{
    public interface IPrintService
    {
        void PrintReceipt(Order order);
    }
}