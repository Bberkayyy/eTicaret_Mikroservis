
namespace e_Ticaret.Order.Application.Features.CQRS.Results.AddressResults;

public class GetAddressByIdQueryResult
{
    public int Id { get; set; }
    public string UserId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string District { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public string PostCode { get; set; }
    public string Detail { get; set; }
    public string Detail2 { get; set; }
}
