namespace e_Ticaret.Order.Application.Features.Mediator.Results.OrderingResults;

public class GetAllOrderingQueryResult
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime OrderDate { get; set; }
}
