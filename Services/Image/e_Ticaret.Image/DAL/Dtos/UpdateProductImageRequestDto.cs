namespace e_Ticaret.Image.DAL.Dtos;

public class UpdateProductImageRequestDto
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public IFormFile? ImageFile { get; set; }
}
