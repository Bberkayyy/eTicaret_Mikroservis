using e_Ticaret.Message.DAL.Context;
using e_Ticaret.Message.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace e_Ticaret.Message.Configurations;

public static class MessageDependencies
{
    public static IServiceCollection AddMessageDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<MessageContext>(opt => opt.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        services.AddScoped<IUserMessageService, UserMessageService>();
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["IdentityServerUrl"];
            opt.RequireHttpsMetadata = false;
            opt.Audience = "MessageResource";
        });
        return services;
    }
}
