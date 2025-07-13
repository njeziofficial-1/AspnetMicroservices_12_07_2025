using Basket.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BasketController(IBasketRepository repository, DiscountGrpcService grpcService) : ControllerBase
{
    [HttpGet("{userName}", Name = "GetBasket")]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> GetBasket(string userName)
    {
        var basket = await repository.GetBasketAsync(userName);
        return Ok(basket ?? new ShoppingCart(userName));
    }

    [HttpPost]
    [ProducesResponseType(typeof(ShoppingCart), StatusCodes.Status200OK)]
    public async Task<ActionResult<ShoppingCart>> UpdateBasket([FromBody]ShoppingCart basket)
    {
        foreach (var item in basket.Items)
        {
            var coupon = await grpcService.GetDiscount(item.ProductName);
            if (coupon != null && !string.IsNullOrEmpty(coupon.ProductName))
            {
                item.Price -= coupon.Amount;
            }
        }
        return Ok(await repository.UpdateBasketAsync(basket));
    }

    [HttpDelete("{userName}", Name = "DeleteBasket")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBasket(string userName)
    {
        if (await repository.BasketExistsAsync(userName))
        {
            await repository.DeleteBasketAsync(userName);
            return NoContent();
        }
        return NotFound();
    }
}
