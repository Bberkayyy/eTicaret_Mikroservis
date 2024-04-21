namespace e_Ticaret.Catalog.Dtos.DiscountOfferDtos;

public class GetDiscountOfferResponseDto
{
    public string Id { get; set; }
    public int DiscountRate { get; set; }
    public string Title { get; set; }
    public string ImageUrl { get; set; }
    public bool IsActive { get; set; }
}
