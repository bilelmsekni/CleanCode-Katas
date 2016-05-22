using System.Collections.Generic;

namespace SolidPrinciples.Model
{
    public class Order
    {
        public double TotalAmount { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public string CustomerEmail { get; set; }
    }
}