namespace SPO.Models
{
    public class Order
    {
        public int id { get; set; }
        public int orderId { get; set; }
        public string customerName { get; set; }
        public string sweaterType { get; set; }
        public int quantity { get; set; }
        public string orderDate { get; set; }
        public string status { get; set; }
    }
}
