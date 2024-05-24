using e_Ticaret.Comment.Context;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace e_Ticaret.Comment.Configurations;

public static class CommentDependencies
{
    public static IServiceCollection AddCommentDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CommentContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DbConnection")));

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
        {
            opt.Authority = configuration["IdentityServerUrl"];
            opt.RequireHttpsMetadata = false;
            opt.Audience = "CommentResource";
        });

        AuthorizationPolicy requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        services.AddControllers(opt =>
        {
            opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
        });

        return services;
    }
}
