namespace e_Ticaret.WebUI.Services.StatisticServices.MessageStatisticServices;

public interface IMessageStatisticService
{
    Task<int> GetMessageCount();
    Task<int> GetNumberOfIncomingMessage(string receiverId);
}
