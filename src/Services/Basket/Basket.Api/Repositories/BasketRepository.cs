
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;

namespace Basket.Api.Repositories;

public class BasketRepository(IDistributedCache redisCache) : IBasketRepository
{

    public async Task<bool> BasketExistsAsync(string userName)
    {
        var basket = await redisCache.GetStringAsync(userName);
        return !string.IsNullOrEmpty(basket);
    }

    public async Task<bool> DeleteBasketAsync(string userName)
    {
        await redisCache.RemoveAsync(userName);
        return true;
    }

    public async Task<ShoppingCart?> GetBasketAsync(string userName)
    {
        var basket = await redisCache.GetStringAsync(userName);
        if (string.IsNullOrEmpty(basket))
        {
            return null;
        }

        return JsonConvert.DeserializeObject<ShoppingCart>(basket);
    }

    public async Task<ShoppingCart?> UpdateBasketAsync(ShoppingCart basket)
    {
        await redisCache.SetStringAsync(basket.UserName, JsonConvert.SerializeObject(basket), 
            new DistributedCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = TimeSpan.FromDays(30)
            });
        return await GetBasketAsync(basket.UserName);
    }
}
