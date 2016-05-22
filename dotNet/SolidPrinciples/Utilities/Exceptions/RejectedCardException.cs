namespace SolidPrinciples.Utilities.Exceptions
{
    internal class RejectedCardException : OrderException
    {
        public RejectedCardException(string exceptionMessage) : base(exceptionMessage)
        {
        }
    }
}