namespace OrderAPI
{
    public class OrderClass
    {
        public int Id { get; set; }
        public String customer_name { get; set; }
        public String product_name { get; set; }
        public int quantity { get; set; }
        public int total_price { get; set; }
        public DateOnly order_date { get; set; }
        public String shipping_address { get; set; }
        public String status { get; set; }
    }
}
