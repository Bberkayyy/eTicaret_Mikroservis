using e_Ticaret.WebUI.Handlers;
using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUI.Services.Concrete;
using e_Ticaret.WebUI.Settings;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace e_Ticaret.WebUI;

public static class UiDependencies
{
    public static IServiceCollection AddUiExtensions(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddCookie(JwtBearerDefaults.AuthenticationScheme, opt =>
        {
            opt.LoginPath = "/login/loginform/";
            opt.LoginPath = "/login/logoutform/";
            opt.AccessDeniedPath = "/pages/accessdenied/";
            opt.Cookie.HttpOnly = true;
            opt.Cookie.SameSite = SameSiteMode.Strict;
            opt.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            opt.Cookie.Name = "e_TicaretJwt";
        });

        services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, opt =>
        {
            opt.LoginPath = "/login/loginform/";
            opt.ExpireTimeSpan = TimeSpan.FromDays(1);
            opt.Cookie.Name = "e_ticaretCookie";
            opt.SlidingExpiration = true;
        });

        services.Configure<ClientSettings>(configuration.GetSection("ClientSettings"));
        services.Configure<ServiceApiSettings>(configuration.GetSection("ServiceApiSettings"));

        services.AddScoped<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpContextAccessor();
        services.AddScoped<ILoginService, LoginService>();
        services.AddScoped<IIdentityService, IdentityService>();

        ServiceApiSettings values = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        services.AddHttpClient<IUserService, UserService>(opt =>
        {
            opt.BaseAddress = new Uri(values.IdentityServerUrl);
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient();

        return services;
    }
}
