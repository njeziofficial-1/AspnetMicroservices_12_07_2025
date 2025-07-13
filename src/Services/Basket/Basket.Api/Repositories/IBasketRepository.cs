namespace Basket.Api.Repositories;

public interface IBasketRepository
{
    Task<ShoppingCart> GetBasketAsync(string userName);
    Task<ShoppingCart> UpdateBasketAsync(ShoppingCart basket);
    Task<bool> DeleteBasketAsync(string userName);
    Task<bool> BasketExistsAsync(string userName);
}
