using e_Ticaret.Cargo.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;

namespace e_Ticaret.Cargo.DataAccessLayer.Context;

public class CargoContext : DbContext
{
    public CargoContext(DbContextOptions<CargoContext> opt) : base(opt)
    {

    }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Detail> Details { get; set; }
    public DbSet<Operation> Operations { get; set; }
    public DbSet<Sender> Senders { get; set; }
}
