using e_Ticaret.Discount.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace e_Ticaret.Discount.Context;

public class DapperContext : DbContext
{
    private readonly IConfiguration _configuration;
    private readonly string _connectionString;
    public DapperContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _connectionString = configuration.GetConnectionString("DbConnection");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server = (localdb)\\MSSQLLocalDB; initial Catalog = e_TicaretDiscountDb; integrated Security = true");
    }
    public DbSet<DiscountCoupon> DiscountCoupons { get; set; }
    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}
