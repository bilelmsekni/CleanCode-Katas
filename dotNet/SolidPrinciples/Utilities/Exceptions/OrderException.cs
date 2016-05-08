using System;

namespace SolidPrinciples.Utilities.Exceptions
{
    internal class OrderException : Exception
    {
        public OrderException(string exceptionMessage, Exception innerException):
            base(exceptionMessage, innerException)
        {
        }
    }
}