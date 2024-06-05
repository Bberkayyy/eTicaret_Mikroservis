using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.BasketDtos;

public class BasketTotalDto
{
    public string UserId { get; set; }
    public string? DiscountCouponCode { get; set; }
    public int DiscountCouponRate { get; set; }
    public List<BasketItemsDto> BasketItems { get; set; }
    public decimal TotalPrice { get => BasketItems.Sum(x => x.UnitPrice * x.Quantity); }
}
