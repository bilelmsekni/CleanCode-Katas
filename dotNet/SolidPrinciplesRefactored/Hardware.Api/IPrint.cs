using SolidPrinciplesRefactored.Services;

namespace SolidPrinciplesRefactored.Hardware.Api
{
    public interface IPrint
    {
        void Print(Receipt receipt);
    }
}