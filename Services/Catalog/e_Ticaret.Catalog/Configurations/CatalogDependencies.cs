using e_Ticaret.Catalog.Services.CategoryServices;
using e_Ticaret.Catalog.Services.ProductDetailServices;
using e_Ticaret.Catalog.Services.ProductImageServices;
using e_Ticaret.Catalog.Services.ProductServices;
using e_Ticaret.Catalog.Settings;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace e_Ticaret.Catalog.Configurations;

public static class CatalogDependencies
{
    public static IServiceCollection AddCatalogDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<DatabaseSettings>(configuration.GetSection("DatabaseSettings"));
        services.AddScoped<IDatabaseSettings>(serviceProvider =>
        {
            return serviceProvider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
        });

        services.AddScoped<ICategoryService, CategoryManager>();
        services.AddScoped<IProductService, ProductManager>();
        services.AddScoped<IProductDetailService, ProductDetailManager>();
        services.AddScoped<IProductImageService, ProductImageManager>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
