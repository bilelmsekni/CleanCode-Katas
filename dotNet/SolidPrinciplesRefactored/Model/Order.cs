using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesRefactored.Model
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}
