using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using RedisCartAPI.Entities;

namespace RedisCartAPI.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly IDistributedCache distributedCache;

        public CartRepository(IDistributedCache distributedCache)
        {
            this.distributedCache = distributedCache;
        }

        public async Task<Cart> GetCartAsync(string userName)
        {
            var cartRecord = await distributedCache.GetStringAsync(userName);
            if (string.IsNullOrEmpty(cartRecord)) return null;
            var cart = JsonConvert.DeserializeObject<Cart>(cartRecord);
            return cart;
        }

        public async Task<Cart> InsertCartAsync(Cart cart)
        {
            var cartString = JsonConvert.SerializeObject(cart);
            await distributedCache.SetStringAsync(cart.UserName, cartString);
            var cartRecord = await distributedCache.GetStringAsync(cart.UserName);
            cart = JsonConvert.DeserializeObject<Cart>(cartRecord);
            return cart;
        }

        public async Task DeleteCartAsync(string userName)
        {
            await distributedCache.RemoveAsync(userName);
        }
    }
}
