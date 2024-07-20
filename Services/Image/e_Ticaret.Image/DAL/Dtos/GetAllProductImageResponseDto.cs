using System.ComponentModel.DataAnnotations.Schema;

namespace e_Ticaret.Image.DAL.Dtos;

public class GetAllProductImageResponseDto
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public string? SavedUrl { get; set; }
    public string? PhotoUrl { get; set; }
    public string? SavedFileName { get; set; }
}
