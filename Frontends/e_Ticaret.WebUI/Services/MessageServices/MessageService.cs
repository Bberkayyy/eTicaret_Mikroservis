using e_Ticaret.WebUIDtos.MessageDtos;
using NuGet.Protocol.Plugins;

namespace e_Ticaret.WebUI.Services.MessageServices;

public class MessageService : IMessageService
{
    private readonly HttpClient _httpClient;

    public MessageService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<ResultMessageInboxDto>> GetMessageInboxAsync(string receiverId)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("usermessages/getinbox/" + receiverId);
        List<ResultMessageInboxDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultMessageInboxDto>>();
        return values;
    }

    public async Task<List<ResultMessageSendboxDto>> GetMessageSendboxAsync(string senderId)
    {
        HttpResponseMessage responseMessage = await _httpClient.GetAsync("usermessages/getsendbox/" + senderId);
        List<ResultMessageSendboxDto>? values = await responseMessage.Content.ReadFromJsonAsync<List<ResultMessageSendboxDto>>();
        return values;
    }
}
