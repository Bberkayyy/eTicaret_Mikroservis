
namespace e_Ticaret.Image.DAL.Dtos;

public class UploadProductImageRequestDto
{
    public string ProductId { get; set; }
    public IFormFile? ImageFile { get; set; }
}
