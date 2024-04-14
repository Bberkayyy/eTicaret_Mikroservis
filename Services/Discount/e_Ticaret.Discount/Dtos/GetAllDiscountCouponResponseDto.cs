namespace e_Ticaret.Discount.Dtos;

public class GetAllDiscountCouponResponseDto
{
    public int Id { get; set; }
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool IsActive { get; set; }
    public DateTime ValidDate { get; set; }
}
