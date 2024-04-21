namespace e_Ticaret.Catalog.Dtos.DiscountOfferDtos;

public class CreateDiscountOfferRequestDto
{
    public int DiscountRate { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public bool IsActive = false;
}
