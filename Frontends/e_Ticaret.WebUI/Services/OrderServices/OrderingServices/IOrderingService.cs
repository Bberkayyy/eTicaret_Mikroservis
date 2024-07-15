using e_Ticaret.WebUIDtos.OrderDtos.OrderingDtos;

namespace e_Ticaret.WebUI.Services.OrderServices.OrderingServices;

public interface IOrderingService
{
    Task<List<ResultOrderingDto>> GetOrderingByUserIdAsync(string id);
}
