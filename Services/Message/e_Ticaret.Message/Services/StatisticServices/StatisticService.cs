
using e_Ticaret.Message.DAL.Context;
using Microsoft.EntityFrameworkCore;

namespace e_Ticaret.Message.Services.StatisticServices;

public class StatisticService : IStatisticService
{
    private readonly MessageContext _messageContext;

    public StatisticService(MessageContext messageContext)
    {
        _messageContext = messageContext;
    }

    public async Task<int> GetMessageCount()
    {
        return await _messageContext.UserMessages.CountAsync();
    }
    public Task<int> GetNumberOfIncomingMessage(string receiverId)
    {
        return _messageContext.UserMessages.Where(x => x.ReceiverId == receiverId).CountAsync();
    }
}
