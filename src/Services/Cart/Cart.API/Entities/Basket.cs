namespace Cart.API.Entities;

public class Basket
{
    public string UserName{ get; set; }

    public BasketItem Items{ get; set; }

    public double Total{ get; set; }
}