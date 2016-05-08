using System;

namespace SolidPrinciples.Utilities.Exceptions
{
    internal class UnAuthorizedContactLessPayment : Exception
    {
        public UnAuthorizedContactLessPayment(string message)
        {
            throw new OrderException(message, this);
        }
    }
}