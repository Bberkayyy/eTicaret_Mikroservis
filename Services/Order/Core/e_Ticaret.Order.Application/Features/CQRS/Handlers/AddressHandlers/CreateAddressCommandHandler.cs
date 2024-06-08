using e_Ticaret.Order.Application.Features.CQRS.Commands.AddressCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class CreateAddressCommandHandler
{
    private readonly IGenericRepository<Address> _repository;

    public CreateAddressCommandHandler(IGenericRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateAddressCommand createAddressCommand)
    {
        await _repository.CreateAsync(new Address
        {
            UserId = createAddressCommand.UserId,
            FirstName = createAddressCommand.FirstName,
            LastName = createAddressCommand.LastName,
            Email = createAddressCommand.Email,
            Phone = createAddressCommand.Phone,
            District = createAddressCommand.District,
            City = createAddressCommand.City,
            Country = createAddressCommand.Country,
            PostCode = createAddressCommand.PostCode,
            Detail = createAddressCommand.Detail,
            Detail2 = createAddressCommand.Detail2,
        });
    }
}