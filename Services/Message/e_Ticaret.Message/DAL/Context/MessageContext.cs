using e_Ticaret.Message.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Ticaret.Message.DAL.Context;

public class MessageContext : DbContext
{
    public MessageContext(DbContextOptions<MessageContext> options) : base(options)
    {

    }
    public DbSet<UserMessage> UserMessages { get; set; }
}
