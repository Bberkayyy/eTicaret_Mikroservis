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
            District = createAddressCommand.District,
            City = createAddressCommand.City,
            Detail = createAddressCommand.Detail
        });
    }
}
