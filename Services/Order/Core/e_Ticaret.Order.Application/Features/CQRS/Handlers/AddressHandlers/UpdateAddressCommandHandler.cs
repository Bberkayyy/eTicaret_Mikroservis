using e_Ticaret.Order.Application.Features.CQRS.Commands.AddressCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class UpdateAddressCommandHandler
{
    private readonly IGenericRepository<Address> _repository;

    public UpdateAddressCommandHandler(IGenericRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateAddressCommand updateAddressCommand)
    {
        Address value = await _repository.GetByFilterAsync(x => x.Id == updateAddressCommand.Id);
        value.UserId = updateAddressCommand.UserId;
        value.City = updateAddressCommand.City;
        value.District = updateAddressCommand.District;
        value.Detail = updateAddressCommand.Detail;
        await _repository.UpdateAsync(value);
    }
}
