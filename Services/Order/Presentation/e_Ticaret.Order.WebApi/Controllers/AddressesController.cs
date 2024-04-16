using e_Ticaret.Order.Application.Features.CQRS.Commands.AddressCommands;
using e_Ticaret.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using e_Ticaret.Order.Application.Features.CQRS.Queries.AddressQueries;
using e_Ticaret.Order.Application.Features.CQRS.Results.AddressResults;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Order.WebApi.Controllers;

[Authorize]
[Route("api/addresses")]
[ApiController]
public class AddressesController : ControllerBase
{
    private readonly GetAllAddressQueryHandler _getAllAddressQueryHandler;
    private readonly GetAddressByIdQueryHandler _getAddressByIdQueryHandler;
    private readonly CreateAddressCommandHandler _createAddressCommandHandler;
    private readonly UpdateAddressCommandHandler _updateAddressCommandHandler;
    private readonly DeleteAddressCommandHandler _deleteAddressCommandHandler;

    public AddressesController(GetAllAddressQueryHandler getAddressQueryHandler, GetAddressByIdQueryHandler getAddressByIdQueryHandler, CreateAddressCommandHandler createAddressCommandHandler, DeleteAddressCommandHandler deleteAddressCommandHandler, UpdateAddressCommandHandler updateAddressCommandHandler)
    {
        _getAllAddressQueryHandler = getAddressQueryHandler;
        _getAddressByIdQueryHandler = getAddressByIdQueryHandler;
        _createAddressCommandHandler = createAddressCommandHandler;
        _deleteAddressCommandHandler = deleteAddressCommandHandler;
        _updateAddressCommandHandler = updateAddressCommandHandler;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllAddressQueryResult> values = await _getAllAddressQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAddress(int id)
    {
        GetAddressByIdQueryResult value = await _getAddressByIdQueryHandler.Handle(new GetAddressByIdQuery(id));
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateAddress(CreateAddressCommand createAddressCommand)
    {
        await _createAddressCommandHandler.Handle(createAddressCommand);
        return Ok("Adres bilgisi başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAddress(DeleteAddressCommand deleteAddressCommand)
    {
        await _deleteAddressCommandHandler.Handle(deleteAddressCommand);
        return Ok("Adres bilgisi başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateAddress(UpdateAddressCommand updateAddressCommand)
    {
        await _updateAddressCommandHandler.Handle(updateAddressCommand);
        return Ok("Adres bilgisi başarıyla güncellendi.");
    }
}
