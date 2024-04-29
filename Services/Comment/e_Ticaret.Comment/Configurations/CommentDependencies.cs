using e_Ticaret.Comment.Context;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace e_Ticaret.Comment.Configurations;

public static class CommentDependencies
{
    public static IServiceCollection AddCommentDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CommentContext>(opt => opt.UseSqlServer(configuration.GetConnectionString("DbConnection")));

        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        //AuthorizationPolicy requireAuthorizePolicy = new AuthorizationPolicyBuilder().RequireAuthenticatedUser().Build();
        //services.AddControllers(opt =>
        //{
        //    opt.Filters.Add(new AuthorizeFilter(requireAuthorizePolicy));
        //});

        return services;
    }
}
