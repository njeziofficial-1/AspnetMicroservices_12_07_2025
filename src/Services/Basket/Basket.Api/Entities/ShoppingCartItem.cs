namespace Basket.Api.Entities;

public class ShoppingCartItem
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public string Colour { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
}