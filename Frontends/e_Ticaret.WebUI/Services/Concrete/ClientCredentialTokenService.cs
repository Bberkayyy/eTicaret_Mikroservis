using e_Ticaret.WebUI.Services.Abstract;
using e_Ticaret.WebUI.Settings;
using e_Ticaret.WebUIDtos.IdentityDtos.LoginDtos;
using IdentityModel.AspNetCore.AccessTokenManagement;
using IdentityModel.Client;
using Microsoft.Extensions.Options;

namespace e_Ticaret.WebUI.Services.Concrete;

public class ClientCredentialTokenService : IClientCredentialTokenService
{
    private readonly ServiceApiSettings _serviceApiSettings;
    private readonly HttpClient _httpClient;
    private readonly IClientAccessTokenCache _clientAccessTokenCache;
    private readonly ClientSettings _clientSettings;

    public ClientCredentialTokenService(IOptions<ServiceApiSettings> serviceApiSettings, HttpClient httpClient, IClientAccessTokenCache clientAccessTokenCache, IOptions<ClientSettings> clientSettings)
    {
        _serviceApiSettings = serviceApiSettings.Value;
        _httpClient = httpClient;
        _clientAccessTokenCache = clientAccessTokenCache;
        _clientSettings = clientSettings.Value;
    }

    public async Task<string> GetToken()
    {
        ClientAccessToken currentToken = await _clientAccessTokenCache.GetAsync("e_ticaretToken");
        if (currentToken != null)
            return currentToken.AccessToken;
        DiscoveryDocumentResponse discoveryEndPoint = await _httpClient.GetDiscoveryDocumentAsync(new DiscoveryDocumentRequest
        {
            Address = _serviceApiSettings.IdentityServerUrl,
            Policy = new DiscoveryPolicy
            {
                RequireHttps = false
            }
        });
        ClientCredentialsTokenRequest clientCredentialTokenRequest = new()
        {
            ClientId = _clientSettings.E_TicaretVisitorClient.ClientId,
            ClientSecret = _clientSettings.E_TicaretVisitorClient.ClientSecret,
            Address = discoveryEndPoint.TokenEndpoint
        };

        TokenResponse newToken = await _httpClient.RequestClientCredentialsTokenAsync(clientCredentialTokenRequest);
        await _clientAccessTokenCache.SetAsync("e_ticaretToken", newToken.AccessToken, newToken.ExpiresIn);

        return newToken.AccessToken;
    }
}
