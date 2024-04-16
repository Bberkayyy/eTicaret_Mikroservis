using e_Ticaret.Discount.Context;
using e_Ticaret.Discount.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace e_Ticaret.Discount.Configurations;

public static class DiscountDependencies
{
    public static IServiceCollection AddDiscountDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddTransient<DapperContext>();
        services.AddTransient<IDiscountService, DiscountManager>();

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["IdentityServerUrl"];
            opt.RequireHttpsMetadata = false;
            opt.Audience = "DiscountResource";
        });
        return services;
    }
}
