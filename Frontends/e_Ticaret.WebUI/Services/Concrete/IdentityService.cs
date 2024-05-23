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
    private readonly ServiceApiSettings _serviceApiSettings;

    public IdentityService(HttpClient httpClient, IHttpContextAccessor contextAccessor, IOptions<ClientSettings> clientSettings, IOptions<ServiceApiSettings> serviceApiSettings)
    {
        _httpClient = httpClient;
        _contextAccessor = contextAccessor;
        _clientSettings = clientSettings.Value;
        _serviceApiSettings = serviceApiSettings.Value;
    }

    public async Task<bool> GetRefreshToken()
    {
        DiscoveryDocumentResponse discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });

        string refreshToken = await _contextAccessor.HttpContext.GetTokenAsync(OpenIdConnectParameterNames.RefreshToken);

        RefreshTokenRequest refreshTokenRequest = new()
        {
            ClientId = _clientSettings.E_TicaretManagerClient.ClientId,
            ClientSecret = _clientSettings.E_TicaretManagerClient.ClientSecret,
            RefreshToken = refreshToken,
            Address = discoveryEndPoint.TokenEndpoint
        };

        TokenResponse token = await _httpClient.RequestRefreshTokenAsync(refreshTokenRequest);

        List<AuthenticationToken> authenticationToken = new()
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
        };
        var result = await _contextAccessor.HttpContext.AuthenticateAsync();

        AuthenticationProperties properties = result.Properties;
        properties.StoreTokens(authenticationToken);

        await _contextAccessor.HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, result.Principal, properties);

        return true;
    }

    public async Task<bool> SignIn(SignInDto signInDto)
    {
        DiscoveryDocumentResponse discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });

        PasswordTokenRequest passwordTokenRequest = new()
        {
            ClientId = _clientSettings.E_TicaretManagerClient.ClientId,
            ClientSecret = _clientSettings.E_TicaretManagerClient.ClientSecret,
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
        //kontrol
        return true;
    }
}
