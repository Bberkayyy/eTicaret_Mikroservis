
namespace e_Ticaret.WebUI.Services.StatisticServices.UserStatisticServices;

public class UserStatisticService : IUserStatisticService
{
    private readonly HttpClient _httpClient;

    public UserStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetUserCount()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("/api/statistics/getusercount");
        int value = await responseMessage.Content.ReadFromJsonAsync<int>();
        return value;
    }
}
