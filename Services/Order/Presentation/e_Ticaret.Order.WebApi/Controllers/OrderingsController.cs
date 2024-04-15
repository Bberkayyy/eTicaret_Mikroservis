using e_Ticaret.Order.Application.Features.Mediator.Commands.OrderingCommands;
using e_Ticaret.Order.Application.Features.Mediator.Queries.OrderingQueries;
using e_Ticaret.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Order.WebApi.Controllers;

[Route("api/orderings")]
[ApiController]
public class OrderingsController : ControllerBase
{
    private readonly IMediator _mediator;

    public OrderingsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllOrderingQueryResult> values = await _mediator.Send(new GetAllOrderingQuery());
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrdering(int id)
    {
        GetOrderingByIdQueryResult value = await _mediator.Send(new GetOrderingByIdQuery(id));
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrdering(CreateOrderingCommand createOrderingCommand)
    {
        await _mediator.Send(createOrderingCommand);
        return Ok("Sipariş başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteOrdering(DeleteOrderingCommand deleteOrderingCommand)
    {
        await _mediator.Send(deleteOrderingCommand);
        return Ok("Sipariş başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
    {
        await _mediator.Send(updateOrderingCommand);
        return Ok("Sipariş başarıyla güncellendi.");
    }
}
