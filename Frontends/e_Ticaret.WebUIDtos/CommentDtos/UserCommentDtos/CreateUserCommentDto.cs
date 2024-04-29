using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;

public class CreateUserCommentDto
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
