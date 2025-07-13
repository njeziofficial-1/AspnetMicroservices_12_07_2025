namespace Basket.Api.Entities;

public class ShoppingCart(string userName)
{
    public string UserName { get; set; } = userName;
    public List<ShoppingCartItem> Items { get; set; } = [];
    public double TotalPrice => Items.Sum(item => item.Price * item.Quantity);

    public void AddItem(ShoppingCartItem item)
    {
        Items.Add(item);
    }
    public void RemoveItem(ShoppingCartItem item)
    {
        Items.Remove(item);
    }
}
