using e_Ticaret.Order.Application.Features.CQRS.Results.AddressResults;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;
using System.Linq;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAllAddressQueryHandler
{
    private readonly IGenericRepository<Address> _repository;

    public GetAllAddressQueryHandler(IGenericRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetAllAddressQueryResult>> Handle()
    {
        IEnumerable<Address> values = await _repository.GetAllAsync();
        return values.Select(x => new GetAllAddressQueryResult
        {
            Id = x.Id,
            UserId = x.UserId,
            FirstName = x.FirstName,
            LastName = x.LastName,
            Email = x.Email,
            Phone = x.Phone,
            District = x.District,
            City = x.City,
            Country = x.Country,
            PostCode = x.PostCode,
            Detail = x.Detail,
            Detail2 = x.Detail2,
        }).ToList();
    }
}
