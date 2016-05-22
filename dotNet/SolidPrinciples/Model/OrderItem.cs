namespace SolidPrinciples.Model
{
    public class OrderItem
    {
        public string ItemId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public double Discount { get; set; }
    }
}