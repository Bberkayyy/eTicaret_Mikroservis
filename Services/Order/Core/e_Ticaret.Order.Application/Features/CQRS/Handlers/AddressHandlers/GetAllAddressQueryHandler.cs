using e_Ticaret.Order.Application.Features.CQRS.Results.AddressResults;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

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
            City = x.City,
            Detail = x.Detail,
            District = x.District,
        }).ToList();
    }
}
