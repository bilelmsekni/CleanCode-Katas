using SolidPrinciples.Model;

namespace SolidPrinciples.Hardware.Api
{
    internal interface IPrinter
    {
        void Print(Receipt receipt);
    }
}