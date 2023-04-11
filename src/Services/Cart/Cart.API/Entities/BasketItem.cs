namespace Cart.API.Entities;

public class BasketItem
{
    public string ProductId { get; set; }

    public string ProductName { get; set; }

    public int Quantity { get; set; }

    public double Amount { get; set; }
}