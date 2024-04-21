using e_Ticaret.Catalog.Services.AboutServices;
using e_Ticaret.Catalog.Services.BrandServices;
using e_Ticaret.Catalog.Services.CategoryServices;
using e_Ticaret.Catalog.Services.DiscountOfferServices;
using e_Ticaret.Catalog.Services.FeatureSliderServices;
using e_Ticaret.Catalog.Services.ProductDetailServices;
using e_Ticaret.Catalog.Services.ProductImageServices;
using e_Ticaret.Catalog.Services.ProductServices;
using e_Ticaret.Catalog.Services.ServiceServices;
using e_Ticaret.Catalog.Services.SpecialOfferServices;
using e_Ticaret.Catalog.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
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
        services.AddScoped<IFeatureSliderService, FeatureSliderManager>();
        services.AddScoped<ISpecialOfferService, SpecialOfferManager>();
        services.AddScoped<IServiceService, ServiceManager>();
        services.AddScoped<IDiscountOfferService, DiscountOfferManager>();
        services.AddScoped<IBrandService, BrandManager>();
        services.AddScoped<IAboutService, AboutManager>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["IdentityServerUrl"];
            opt.RequireHttpsMetadata = false;
            opt.Audience = "CatalogResource";
        });

        AuthorizationPolicy requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        services.AddControllers(opt =>
        {
            opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
        });

        return services;
    }
}
