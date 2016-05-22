using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesRefactored.Utilities.Exceptions
{
    public class NotValidPaymentException : OrderException
    {
        public NotValidPaymentException(string message) : base(message)
        {
            
        }
    }
}
