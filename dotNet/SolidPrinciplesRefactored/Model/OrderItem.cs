using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolidPrinciplesRefactored.Model
{
    public class OrderItem
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public int ItemId { get; set; }
    }
}
