using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.MessageDtos;

public class ResultMessageInboxDto
{
    public int id { get; set; }
    public string senderId { get; set; }
    public string receiverId { get; set; }
    public string subject { get; set; }
    public string messageDetail { get; set; }
    public bool isRead { get; set; }
    public DateTime sendDate { get; set; }
}
