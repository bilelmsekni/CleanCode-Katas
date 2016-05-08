using System.Collections;
using System.Collections.Generic;

namespace SolidPrinciples.Model
{
    public class Cart
    {
        public double TotalAmount { get; set; }
        public IEnumerable<OrderItem> Items { get; set; }
        public string CustomerEmail { get; set; }
    }
}