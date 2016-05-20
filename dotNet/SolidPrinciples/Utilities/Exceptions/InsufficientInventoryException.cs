using System;

namespace SolidPrinciples.Utilities.Exceptions
{
    public class InsufficientInventoryException : OrderException
    {
        public InsufficientInventoryException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}