using SolidPrinciplesRefactored.Services;

namespace SolidPrinciplesRefactored.Hardware.Api
{
    public interface IScan
    {
        void Scan(Receipt receipt);
    }
}
