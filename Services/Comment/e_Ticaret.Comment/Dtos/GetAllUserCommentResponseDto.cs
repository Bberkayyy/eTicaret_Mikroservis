namespace e_Ticaret.Comment.Dtos;

public class GetAllUserCommentResponseDto
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public string FullName { get; set; }
    public string? ImageUrl { get; set; }
    public string Email { get; set; }
    public string Detail { get; set; }
    public int Rating { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public bool IsActive { get; set; }
}
