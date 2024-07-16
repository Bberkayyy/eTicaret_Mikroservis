using e_Ticaret.Message.Dtos;

namespace e_Ticaret.Message.Services;

public interface IUserMessageService
{
    Task<List<GetAllMessageResponseDto>> GetAllMessageAsync();
    Task<List<ResultMessageInboxResponseDto>> GetMessageInboxAsync(string receiverId);
    Task<List<ResultMessageSendboxResponseDto>> GetMessageSendboxAsync(string senderId);
    Task CreateMessageAsync(CreateMessageRequestDto createMessageRequestDto);
    Task UpdateMessageAsync(UpdateMessageRequestDto updateMessageRequestDto);
    Task DeleteMessageAsync(int id);
    Task<GetMessageByIdResponseDto> GetMessageByIdAsync(int id);
}
