
namespace e_Ticaret.WebUI.Services.StatisticServices.MessageStatisticServices;

public class MessageStatisticService : IMessageStatisticService
{
    private readonly HttpClient _httpClient;

    public MessageStatisticService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<int> GetMessageCount()
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getmessagecount");
        int value = await responseMessage.Content.ReadFromJsonAsync<int>();
        return value;
    }

    public async Task<int> GetNumberOfIncomingMessage(string receiverId)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("statistics/getnumberofincomingmessage?receiverId=" + receiverId);
        int value = await responseMessage.Content.ReadFromJsonAsync<int>();
        return value;
    }
}
