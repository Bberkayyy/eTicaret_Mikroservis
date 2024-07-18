namespace e_Ticaret.Message.Services.StatisticServices;

public interface IStatisticService
{
    Task<int> GetMessageCount();
    Task<int> GetNumberOfIncomingMessage(string receiverId);
}
