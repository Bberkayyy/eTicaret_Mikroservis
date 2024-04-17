using e_Ticaret.Cargo.DataAccessLayer.Abstract;
using e_Ticaret.Cargo.DataAccessLayer.Context;
using e_Ticaret.Cargo.DataAccessLayer.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace e_Ticaret.Cargo.DataAccessLayer;

public static class DataAccessDependencies
{
    public static IServiceCollection AddDataAccessRegistrations(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CargoContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DbConnection")));

        services.AddScoped<ICompanyDal, EfCompanyDal>();
        services.AddScoped<IDetailDal, EfDetailDal>();
        services.AddScoped<IOperationDal, EfOperationDal>();
        services.AddScoped<ISenderDal, EfSenderDal>();

        return services;
    }
}
