using e_Ticaret.Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Ticaret.Comment.Context;

public class CommentContext : DbContext
{
    public CommentContext(DbContextOptions<CommentContext> opt) : base(opt)
    {

    }
    public DbSet<UserComment> UserComments { get; set; }
}
