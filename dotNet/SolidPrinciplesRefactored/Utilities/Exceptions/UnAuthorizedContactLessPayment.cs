namespace SolidPrinciplesRefactored.Utilities.Exceptions
{
    public class UnAuthorizedContactLessPayment : OrderException
    {
        public UnAuthorizedContactLessPayment(string exceptionMessage)
            : base(exceptionMessage)
        { }
    }
}