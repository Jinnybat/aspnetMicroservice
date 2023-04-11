using System.Text.Json;
using Cart.API.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace Cart.API.Repository;

public class CartRepository : ICartRepository
{
    private readonly IDistributedCache redis;

    public CartRepository(IDistributedCache redis)
    {
        this.redis = redis;
    }

    public async Task<Basket> GetBasket(string userName)
    {
        var value = await redis.GetStringAsync(userName);

        var basket = JsonSerializer.Deserialize<Basket>(value);
        return basket;
    }

    public async Task<Basket> RemoveBasket(string userName)
    {
        await redis.RemoveAsync(userName);

        return await GetBasket(userName);
    }

    public async Task<Basket> UpdateBasket(Basket basket)
    {
        var value = JsonSerializer.Serialize(basket);

        await redis.SetStringAsync(basket.UserName, value);

        return await GetBasket(basket.UserName);
    }
}
