namespace e_Ticaret.Message.Dtos;

public class CreateMessageRequestDto
{
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Subject { get; set; }
    public string MessageDetail { get; set; }
    public bool isRead = false;
    public DateTime SendDate { get; set; }
}
