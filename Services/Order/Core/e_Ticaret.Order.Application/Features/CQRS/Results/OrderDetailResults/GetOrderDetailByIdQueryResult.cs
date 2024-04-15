
namespace e_Ticaret.Order.Application.Features.CQRS.Results.OrderDetailResults;

public class GetOrderDetailByIdQueryResult
{
    public int Id { get; set; }
    public int OrderingId { get; set; }
    public string ProductId { get; set; }
    public string ProductName { get; set; }
    public decimal ProductUnitPrice { get; set; }
    public int ProductAmount { get; set; }
    public decimal ProductTotalPrice { get; set; }
}
