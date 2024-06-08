using e_Ticaret.Order.Application.Features.CQRS.Queries.AddressQueries;
using e_Ticaret.Order.Application.Features.CQRS.Results.AddressResults;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class GetAddressByIdQueryHandler
{
    private readonly IGenericRepository<Address> _repository;

    public GetAddressByIdQueryHandler(IGenericRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task<GetAddressByIdQueryResult> Handle(GetAddressByIdQuery getAddressByIdQuery)
    {
        Address values = await _repository.GetByIdAsync(getAddressByIdQuery.Id);
        return new GetAddressByIdQueryResult
        {
            Id = values.Id,
            UserId = values.UserId,
            FirstName = values.FirstName,
            LastName = values.LastName,
            Email = values.Email,
            Phone = values.Phone,
            District = values.District,
            City = values.City,
            Country = values.Country,
            PostCode = values.PostCode,
            Detail = values.Detail,
            Detail2 = values.Detail2,
        };
    }
}
