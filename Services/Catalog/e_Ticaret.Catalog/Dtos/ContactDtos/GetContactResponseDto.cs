namespace e_Ticaret.Catalog.Dtos.ContactDtos;

public class GetContactResponseDto
{
    public string Id { get; set; }
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool IsRead { get; set; }
    public DateTime SendDate { get; set; }
    public DateTime? ReadTime { get; set; }
}
