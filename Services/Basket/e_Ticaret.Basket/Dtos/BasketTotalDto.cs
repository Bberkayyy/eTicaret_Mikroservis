namespace e_Ticaret.Basket.Dtos;

public class BasketTotalDto
{
    public string UserId { get; set; }
    public string DiscountCouponCode { get; set; }
    public int DiscountCouponRate { get; set; }
    public List<BasketItemsDto> BasketItems { get; set; }
    public decimal TotalPrice { get => BasketItems.Sum(x => x.UnitPrice * x.Quantity); }
}
