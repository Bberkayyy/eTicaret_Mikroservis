
namespace e_Ticaret.WebUI.Services.StatisticServices.CommentStatisticServices;

public class CommentStatisticService : ICommentStatisticService
{
    private readonly HttpClient _httpClient;

    public CommentStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public async Task<int> GetActiveCommentCount()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getactivecommentcount");
        int value = await responseMessage.Content.ReadFromJsonAsync<int>();
        return value;
    }

    public async Task<int> GetCommentCount()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getpassivecommentcount");
        int value = await responseMessage.Content.ReadFromJsonAsync<int>();
        return value;
    }

    public async Task<int> GetPassiveCommentCount()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getcommentcount");
        int value = await responseMessage.Content.ReadFromJsonAsync<int>();
        return value;
    }
}
