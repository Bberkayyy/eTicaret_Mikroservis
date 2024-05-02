namespace e_Ticaret.Catalog.Dtos.ContactDtos;

public class CreateContactRequestDto
{
    public string Fullname { get; set; }
    public string Email { get; set; }
    public string Subject { get; set; }
    public string Message { get; set; }
    public bool IsRead = false;
    public DateTime SendDate = DateTime.Now;
}
