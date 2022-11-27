using RedisCartAPI.Entities;

namespace RedisCartAPI.Repository
{
    public interface ICartRepository
    {
        public Task<Cart> GetCartAsync(string userName);
        public Task<Cart> InsertCartAsync(Cart cart);
        public Task DeleteCartAsync(string userName);
    }
}
