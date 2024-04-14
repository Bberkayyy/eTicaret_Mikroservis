namespace e_Ticaret.Discount.Dtos;

public class CreateDiscountCouponRequestDto
{
    public string Code { get; set; }
    public int Rate { get; set; }
    public bool IsActive = true;
    public DateTime ValidDate { get; set; }
}
