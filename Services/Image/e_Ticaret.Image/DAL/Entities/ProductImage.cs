using System.ComponentModel.DataAnnotations.Schema;

namespace e_Ticaret.Image.DAL.Entities;

public class ProductImage
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    [NotMapped]
    public IFormFile? ImageFile { get; set; }
    public string? SavedUrl { get; set; }
    [NotMapped]
    public string? PhotoUrl { get; set; }
    public string? SavedFileName { get; set; }
}
