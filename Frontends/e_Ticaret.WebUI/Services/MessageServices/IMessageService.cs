using e_Ticaret.WebUIDtos.MessageDtos;

namespace e_Ticaret.WebUI.Services.MessageServices;

public interface IMessageService
{
    Task<List<ResultMessageInboxDto>> GetMessageInboxAsync(string receiverId);
    Task<List<ResultMessageSendboxDto>> GetMessageSendboxAsync(string senderId);
}
