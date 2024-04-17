using e_Ticaret.Cargo.BusinessLayer.Abstract;
using e_Ticaret.Cargo.BusinessLayer.Concrete;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace e_Ticaret.Cargo.BusinessLayer;

public static class BusinessDependencies
{
    public static IServiceCollection AddBusinessRegistrations(this IServiceCollection services)
    {
        services.AddScoped<ICompanyService, CompanyManager>();
        services.AddScoped<IDetailService, DetailManager>();
        services.AddScoped<IOperationService, OperationManager>();
        services.AddScoped<ISenderService, SenderManager>();

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        return services;
    }
}
