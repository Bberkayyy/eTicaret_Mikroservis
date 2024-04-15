using e_Ticaret.Order.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace e_Ticaret.Order.Persistence.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = localhost,1440 ; initial Catalog = e_TicaretOrderDb; User = sa; Password = 124578963,0+bB");
    }
    DbSet<Address> Addresses { get; set; }
    DbSet<Ordering> Orderings { get; set; }
    DbSet<OrderDetail> OrderDetails { get; set; }
}
