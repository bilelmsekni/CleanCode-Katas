using System.Collections.Generic;

namespace SolidPrinciplesRefactored.Model
{
    public class Order
    {
        public IEnumerable<OrderItem> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}
