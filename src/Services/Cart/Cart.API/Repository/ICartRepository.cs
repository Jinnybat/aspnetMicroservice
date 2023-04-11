using Cart.API.Entities;

namespace Cart.API.Repository;

public interface ICartRepository
{
    Task<Basket> GetBasket(string userName);

    Task<Basket> UpdateBasket(Basket basket);

    Task<Basket> RemoveBasket(string userName);
}