using e_Ticaret.Discount.Context;
using e_Ticaret.Discount.Services;

namespace e_Ticaret.Discount.Configurations;

public static class DiscountDependencies
{
    public static IServiceCollection AddDiscountDependencies(this IServiceCollection services)
    {
        services.AddTransient<DapperContext>();
        services.AddTransient<IDiscountService, DiscountManager>();
        return services;
    }
}
