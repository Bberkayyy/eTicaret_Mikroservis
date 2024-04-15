
namespace e_Ticaret.Order.Application.Features.CQRS.Results.AddressResults;

public class GetAllAddressQueryResult
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Detail { get; set; }
}
