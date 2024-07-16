using AutoMapper;
using e_Ticaret.Message.DAL.Context;
using e_Ticaret.Message.DAL.Entities;
using e_Ticaret.Message.Dtos;
using Microsoft.EntityFrameworkCore;

namespace e_Ticaret.Message.Services;

public class UserMessageService : IUserMessageService
{
    private readonly MessageContext _messageContext;
    private readonly IMapper _mapper;

    public UserMessageService(MessageContext messageContext, IMapper mapper)
    {
        _messageContext = messageContext;
        _mapper = mapper;
    }

    public async Task CreateMessageAsync(CreateMessageRequestDto createMessageRequestDto)
    {
        UserMessage value = _mapper.Map<UserMessage>(createMessageRequestDto);
        await _messageContext.UserMessages.AddAsync(value);
        await _messageContext.SaveChangesAsync();
    }

    public async Task DeleteMessageAsync(int id)
    {
        UserMessage? value = await _messageContext.UserMessages.FindAsync(id);
        _messageContext.UserMessages.Remove(value);
        await _messageContext.SaveChangesAsync();
    }

    public async Task<List<GetAllMessageResponseDto>> GetAllMessageAsync()
    {
        List<UserMessage> values = await _messageContext.UserMessages.ToListAsync();
        return _mapper.Map<List<GetAllMessageResponseDto>>(values);
    }

    public async Task<GetMessageByIdResponseDto> GetMessageByIdAsync(int id)
    {
        UserMessage? value = await _messageContext.UserMessages.FindAsync(id);
        return _mapper.Map<GetMessageByIdResponseDto>(value);
    }

    public async Task<List<ResultMessageInboxResponseDto>> GetMessageInboxAsync(string receiverId)
    {
        List<UserMessage> values = await _messageContext.UserMessages.Where(x => x.ReceiverId == receiverId).ToListAsync();
        return _mapper.Map<List<ResultMessageInboxResponseDto>>(values);
    }

    public async Task<List<ResultMessageSendboxResponseDto>> GetMessageSendboxAsync(string senderId)
    {
        List<UserMessage> values = await _messageContext.UserMessages.Where(x => x.SenderId == senderId).ToListAsync();
        return _mapper.Map<List<ResultMessageSendboxResponseDto>>(values);
    }

    public async Task UpdateMessageAsync(UpdateMessageRequestDto updateMessageRequestDto)
    {
        UserMessage? value = await _messageContext.UserMessages.FindAsync(updateMessageRequestDto.Id);
        value.SenderId = updateMessageRequestDto.SenderId;
        value.ReceiverId = updateMessageRequestDto.ReceiverId;
        value.Subject = updateMessageRequestDto.Subject;
        value.MessageDetail = updateMessageRequestDto.MessageDetail;
        _messageContext.Update(value);
        await _messageContext.SaveChangesAsync();
    }
}
