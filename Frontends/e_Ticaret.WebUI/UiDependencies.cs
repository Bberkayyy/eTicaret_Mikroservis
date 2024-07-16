using e_Ticaret.WebUI.Handlers;
using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUI.Services.BasketServices;
using e_Ticaret.WebUI.Services.CargoServices.CompanyServices;
using e_Ticaret.WebUI.Services.CatalogServices.AboutServices;
using e_Ticaret.WebUI.Services.CatalogServices.BrandServices;
using e_Ticaret.WebUI.Services.CatalogServices.CategoryServices;
using e_Ticaret.WebUI.Services.CatalogServices.ContactServices;
using e_Ticaret.WebUI.Services.CatalogServices.DiscountOfferServices;
using e_Ticaret.WebUI.Services.CatalogServices.FeatureSliderServices;
using e_Ticaret.WebUI.Services.CatalogServices.ProductDetailServices;
using e_Ticaret.WebUI.Services.CatalogServices.ProductImageServices;
using e_Ticaret.WebUI.Services.CatalogServices.ProductServices;
using e_Ticaret.WebUI.Services.CatalogServices.ServiceServices;
using e_Ticaret.WebUI.Services.CatalogServices.SpecialOfferServices;
using e_Ticaret.WebUI.Services.CommentServices.UserCommentServices;
using e_Ticaret.WebUI.Services.Concrete;
using e_Ticaret.WebUI.Services.DiscountServices.DiscountCouponServices;
using e_Ticaret.WebUI.Services.IdentityServices;
using e_Ticaret.WebUI.Services.MessageServices;
using e_Ticaret.WebUI.Services.OrderServices.AddressServices;
using e_Ticaret.WebUI.Services.OrderServices.OrderingServices;
using e_Ticaret.WebUI.Services.StatisticServices.CatalogStatisticServices;
using e_Ticaret.WebUI.Services.StatisticServices.CommentStatisticServices;
using e_Ticaret.WebUI.Services.StatisticServices.DiscountStatisticServices;
using e_Ticaret.WebUI.Services.StatisticServices.UserStatisticServices;
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

        services.AddAccessTokenManagement();
        services.AddHttpContextAccessor();
        services.AddScoped<ILoginService, LoginService>();
        services.AddHttpClient<IIdentityService, IdentityService>();
        services.AddHttpClient<IClientCredentialTokenService, ClientCredentialTokenService>();

        services.AddScoped<ResourceOwnerPasswordTokenHandler>();
        services.AddScoped<ClientCredentialTokenHandler>();

        ServiceApiSettings values = configuration.GetSection("ServiceApiSettings").Get<ServiceApiSettings>();
        services.AddHttpClient<IUserService, UserService>(opt =>
        {
            opt.BaseAddress = new Uri(values.IdentityServerUrl);
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IUserStatisticService, UserStatisticService>(opt =>
        {
            opt.BaseAddress = new Uri(values.IdentityServerUrl);
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<ICatalogStatisticService, CatalogStatisticService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IMessageService, MessageService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Message.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<ICommentStatisticService, CommentStatisticService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IDiscountStatisticService, DiscountStatisticService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IBasketService, BasketService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Basket.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IAddressService, AddressService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<ICompanyService, CompanyService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Cargo.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IOrderingService, OrderingService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Order.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IDiscountCouponService, DiscountCouponService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Discount.Path}");
        }).AddHttpMessageHandler<ResourceOwnerPasswordTokenHandler>();

        services.AddHttpClient<IRegisterService, RegisterService>(opt =>
        {
            opt.BaseAddress = new Uri(values.IdentityServerUrl);
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<ICategoryService, CategoryService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IProductService, ProductService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IAboutService, AboutService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();
        services.AddHttpClient();

        services.AddHttpClient<IBrandService, BrandService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IContactService, ContactService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IDiscountOfferService, DiscountOfferService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IFeatureSliderService, FeatureSliderService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IProductDetailService, ProductDetailService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IProductImageService, ProductImageService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IServiceService, ServiceService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<ISpecialOfferService, SpecialOfferService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Catalog.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient<IUserCommentService, UserCommentService>(opt =>
        {
            opt.BaseAddress = new Uri($"{values.OcelotUrl}/{values.Comment.Path}");
        }).AddHttpMessageHandler<ClientCredentialTokenHandler>();

        services.AddHttpClient();

        return services;
    }
}
