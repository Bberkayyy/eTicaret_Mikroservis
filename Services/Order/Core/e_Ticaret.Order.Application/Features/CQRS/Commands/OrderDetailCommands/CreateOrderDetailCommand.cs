
namespace e_Ticaret.Order.Application.Features.CQRS.Commands.OrderDetailCommands;

public class CreateOrderDetailCommand
{
    public int OrderingId { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductUnitPrice { get; set; }
    public int ProductAmount { get; set; }
}
