namespace e_Ticaret.Message.DAL.Entities;

public class UserMessage
{
    public int Id { get; set; }
    public string SenderId { get; set; }
    public string ReceiverId { get; set; }
    public string Subject { get; set; }
    public string MessageDetail { get; set; }
    public bool isRead { get; set; }
    public DateTime SendDate { get; set; }
}
