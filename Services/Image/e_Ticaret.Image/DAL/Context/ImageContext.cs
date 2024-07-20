using e_Ticaret.Image.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace e_Ticaret.Image.DAL.Context;

public class ImageContext : DbContext
{
    public ImageContext(DbContextOptions<ImageContext> options) : base(options)
    {

    }
    public DbSet<ProductImage> ProductImages { get; set; }
}

