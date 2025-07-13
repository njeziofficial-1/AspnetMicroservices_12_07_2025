using Discount.Api.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Api.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DiscountController(IDiscountRepository repository) : ControllerBase
{
    [HttpGet("{productName}", Name = "GetDiscount")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<Coupon>> GetDiscount(string productName)
    {
        var coupon = await repository.GetDiscount(productName);
        if (coupon == null)
            return NotFound();
        return Ok(coupon);
    }
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<ActionResult<bool>> CreateDiscount([FromBody] Coupon coupon)
    {
        if (coupon == null)
            return BadRequest();
        var created = await repository.CreateDiscount(coupon);
        if (!created)
            return BadRequest();
        return CreatedAtRoute("GetDiscount", new { productName = coupon.ProductName }, coupon);
    }
    [HttpPut]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<ActionResult<bool>> UpdateDiscount([FromBody] Coupon coupon)
    {
        if (coupon == null)
            return BadRequest();
        var updated = await repository.UpdateDiscount(coupon);
        if (!updated)
            return NotFound();
        return NoContent();
    }
    [HttpDelete("{productName}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<bool>> DeleteDiscount(string productName)
    {
        var deleted = await repository.DeleteDiscount(productName);
        if (!deleted)
            return NotFound();
        return NoContent();
    }
}
