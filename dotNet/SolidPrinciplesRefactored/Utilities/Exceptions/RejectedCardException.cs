using System;

namespace SolidPrinciplesRefactored.Utilities.Exceptions
{
    public class RejectedCardException : OrderException
    {
        public RejectedCardException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}