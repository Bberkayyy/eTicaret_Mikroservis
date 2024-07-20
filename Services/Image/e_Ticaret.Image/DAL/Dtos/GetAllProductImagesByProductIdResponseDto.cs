namespace e_Ticaret.Image.DAL.Dtos;

public class GetAllProductImagesByProductIdResponseDto
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public string? SavedUrl { get; set; }
    public string? PhotoUrl { get; set; }
    public string? SavedFileName { get; set; }
}
