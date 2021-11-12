
using System;
using System.Threading.Tasks;
using BasketService.Data.Models;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace BasketService.Repository
{
    public class BasketRepository : IBasketRepository
    {
        private readonly IDistributedCache _redisCache;

        public BasketRepository(IDistributedCache cache)
        {
            _redisCache = cache ?? throw new ArgumentNullException(nameof(cache));
        }
        public async Task<Basket> GetBasket(string basketId)
        {
            var basket = await _redisCache.GetStringAsync(basketId);

            return string.IsNullOrEmpty(basket) ? null : JsonConvert.DeserializeObject<Basket>(basket);
        }
        public async Task<Basket> CreateBasket(Basket basket)
        {
            await _redisCache.SetStringAsync(basket.Id, JsonConvert.SerializeObject(basket));
            
            return await GetBasket(basket.Id);
        }

        public async Task<Basket> AddItem(Basket basket)
        {
            await _redisCache.SetStringAsync(basket.Id, JsonConvert.SerializeObject(basket));

            return basket;
        }
    }
}