using e_Ticaret.Order.Application.Features.CQRS.Commands.AddressCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.AddressHandlers;

public class DeleteAddressCommandHandler
{
    private readonly IGenericRepository<Address> _repository;

    public DeleteAddressCommandHandler(IGenericRepository<Address> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteAddressCommand deleteAddressCommand)
    {
        Address value = await _repository.GetByFilterAsync(x => x.Id == deleteAddressCommand.Id);
        await _repository.DeleteAsync(value);
    }
}
