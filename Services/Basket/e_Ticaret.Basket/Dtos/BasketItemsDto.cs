namespace e_Ticaret.Basket.Dtos;

public class BasketItemsDto
{
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
}
