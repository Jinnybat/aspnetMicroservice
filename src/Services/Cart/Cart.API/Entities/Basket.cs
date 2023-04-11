namespace Cart.API.Entities;

public class Basket
{
    public string UserName{ get; set; }

    public List<BasketItem> Items{ get; set; }

    public double Total{ get; set; }
}