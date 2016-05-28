using SolidPrinciplesRefactored.Services;

namespace SolidPrinciplesRefactored.Hardware.Api
{
    public interface IFax
    {
        void Fax(Receipt receipt);
    }
}
