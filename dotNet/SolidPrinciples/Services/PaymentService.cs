using System;

namespace SolidPrinciples.Services
{
    internal class PaymentService : IDisposable
    {
        public void Dispose()
        {
            //Disposing            
        }

        public string Credentials { get; set; }
        public object CardNumber { get; set; }
        public object ExpiresMonth { get; set; }
        public object ExpiresYear { get; set; }
        public object NameOnCard { get; set; }
        public object AmountToCharge { get; set; }

        public void Charge()
        {
            //Doing some charging
        }
    }
}