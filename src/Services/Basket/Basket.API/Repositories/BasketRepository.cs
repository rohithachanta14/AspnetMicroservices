using Basket.API.Entities;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Basket.API.Repositories
{
    public class BasketRepository : IBasketRepository
    {

        private readonly IDistributedCache _rediscache_ctx;

        public BasketRepository(IDistributedCache rediscache_ctx)
        {
            _rediscache_ctx = rediscache_ctx ?? throw new ArgumentNullException(nameof(rediscache_ctx));
        }

        public async Task DeleteBasket(string username)
        {
            await _rediscache_ctx.RemoveAsync(username);
        }

        public async Task<ShoppingCart> GetBasket(string username)
        {
            var basket = await _rediscache_ctx.GetStringAsync(username);
            if (String.IsNullOrEmpty(basket))
            {
                return null;
            }

            return JsonConvert.DeserializeObject<ShoppingCart>(basket);
        }

        public async Task<ShoppingCart> UpdateBasket(ShoppingCart basket)
        {
            await _rediscache_ctx.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket));
            return await GetBasket(basket.UserName);

        }
    }
}
