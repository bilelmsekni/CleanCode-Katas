using System;

namespace SolidPrinciplesRefactored.Utilities.Exceptions
{
    public class RejectedCardException : Exception
    {
        public RejectedCardException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}