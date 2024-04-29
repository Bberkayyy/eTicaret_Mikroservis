using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_Ticaret.WebUIDtos.CommentDtos.UserCommentDtos;

public class UpdateUserCommentDto
{
    public int Id { get; set; }
    public string ProductId { get; set; }
    public string FullName { get; set; }
    public string? ImageUrl { get; set; }
    public string Email { get; set; }
    public string Detail { get; set; }
    public int Rating { get; set; }
    public DateTime UpdateDate = DateTime.Now;
    public bool IsActive { get; set; }
}
