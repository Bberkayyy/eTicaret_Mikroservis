using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUI.Settings;
using e_Ticaret.WebUIDtos.IdentityDtos.LoginDtos;
using IdentityModel.Client;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System.Security.Claims;

namespace e_Ticaret.WebUI.Services.Concrete;

public class IdentityService : IIdentityService
{
    private readonly HttpClient _httpClient;
    private readonly IHttpContextAccessor _contextAccessor;
    private readonly ClientSettings _clientSettings;

    public IdentityService(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings)
    {
        _httpClient = httpClient;
        _contextAccessor = contextAccessor;
        _clientSettings = clientSettings.Value;
    }

    public async Task<bool> SignIn(SignInDto signInDto)
    {
        DiscoveryDocumentResponse discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = "http://localhost:5001",
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });

        PasswordTokenRequest passwordTokenRequest = new()
        {
            ClientId = _clientSettings.E_TicaretVisitorClient.ClientId,
            ClientSecret = _clientSettings.E_TicaretVisitorClient.ClientSecret,
            UserName = signInDto.Username,
            Password = signInDto.Password,
            Address = discoveryEndPoint.TokenEndpoint
        };

        TokenResponse token = await _httpClient.RequestPasswordTokenAsync(passwordTokenRequest);

        UserInfoRequest userInfoRequest = new()
        {
            Token = token.AccessToken,
            Address = discoveryEndPoint.UserInfoEndpoint
        };

        var userValues = await _httpClient.GetUserInfoAsync(userInfoRequest);

        ClaimsIdentity claimsIdentity = new(userValues.Claims, CookieAuthenticationDefaults.AuthenticationScheme, "name", "role");

        ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

        AuthenticationProperties authenticationProperties = new();
        authenticationProperties.StoreTokens(new List<AuthenticationToken>()
        {
            new AuthenticationToken
            {
                Name=OpenIdConnectParameterNames.AccessToken,
                Value=token.AccessToken
            },
            new AuthenticationToken
            {
                Name = OpenIdConnectParameterNames.RefreshToken,
                Value = token.RefreshToken
            },
            new AuthenticationToken
            {
                Name=OpenIdConnectParameterNames.ExpiresIn,
                Value = DateTime.Now.AddMinutes(token.ExpiresIn).ToString(),
            }
        });

        authenticationProperties.IsPersistent = false;
        await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, authenticationProperties);
        return true;
    }
}
