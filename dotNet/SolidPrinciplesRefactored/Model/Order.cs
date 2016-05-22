using System.Collections.Generic;

namespace SolidPrinciplesRefactored.Model
{
    public class Order
    {
        public List<OrderItem> Items { get; set; }
        public double TotalAmount { get; set; }
    }
}
