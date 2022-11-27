namespace RedisCartAPI.Entities
{
    public class Cart
    {
        public string UserName { get; set; }
        public IReadOnlyCollection<CartItem> CartItems { get; set; }
        public decimal TotalPrice { get
            {
                if(CartItems != null)
                {
                    return CartItems.Sum(x => x.Price * x.Amount);
                }
                return default;
            }
        }
    }
}
