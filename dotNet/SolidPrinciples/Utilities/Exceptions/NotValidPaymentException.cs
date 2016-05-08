using System;

namespace SolidPrinciples.Utilities.Exceptions
{
    public class NotValidPaymentException : Exception
    {
        public NotValidPaymentException(string message)
        {
            throw new OrderException(message, this);
        }
    }
}