using System;

namespace SolidPrinciplesRefactored.Services
{
    public class CreditCardMachine : IDisposable
    {
        public void Dispose()
        {
            //Disposing    
        }

        public string CardNumber { get; set; }
        public string ExpiresMonth { get; set; }
        public string ExpiresYear { get; set; }
        public string NameOnCard { get; set; }
        public double AmountToCharge { get; set; }

        public void Charge()
        {
            //Do some charging
        }
    }
}