namespace RedisCartAPI.Entities
{
    public class CartItem
    {
        public string Name { get; set; }
        public string Color { get; set; }
        public int Amount { get; set; }
        public decimal Price { get; set; }
    }
}
