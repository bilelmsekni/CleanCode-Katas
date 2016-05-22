using System;

namespace SolidPrinciplesRefactored.Utilities.Exceptions
{
    public class OrderException : Exception
    {
        public OrderException(string exceptionMessage) :
            base(exceptionMessage)
        { }

        public OrderException(string exceptionMessage, OrderException innerException) :
            base(exceptionMessage, innerException)
        { }
    }
}