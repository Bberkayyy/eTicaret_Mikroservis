namespace e_Ticaret.Comment.Dtos;

public class CreateUserCommentRequestDto
{
    public string ProductId { get; set; }
    public string FullName { get; set; }
    public string? ImageUrl { get; set; }
    public string Email { get; set; }
    public string Detail { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedDate = DateTime.Now;
    public bool IsActive = true;
}
