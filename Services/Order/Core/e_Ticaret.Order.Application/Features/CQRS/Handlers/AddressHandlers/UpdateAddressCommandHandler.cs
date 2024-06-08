using e_Ticaret.Order.Application.Features.CQRS.Commands.AddressCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;
using System.Diagnostics.Metrics;
using System.Numerics;

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
        value.FirstName = updateAddressCommand.FirstName;
        value.LastName = updateAddressCommand.LastName;
        value.Email = updateAddressCommand.Email;
        value.Phone = updateAddressCommand.Phone;
        value.District = updateAddressCommand.District;
        value.City = updateAddressCommand.City;
        value.Country = updateAddressCommand.Country;
        value.PostCode = updateAddressCommand.PostCode;
        value.Detail = updateAddressCommand.Detail;
        value.Detail2 = updateAddressCommand.Detail2;
        await _repository.UpdateAsync(value);
    }
}
