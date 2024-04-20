namespace e_Ticaret.Catalog.Dtos.FeatureSliderDtos;

public class CreateFeatureSliderRequestDto
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public bool Status = false;
}
