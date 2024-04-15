using e_Ticaret.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using e_Ticaret.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using e_Ticaret.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using e_Ticaret.Order.Application.Features.CQRS.Results.OrderDetailResults;
using Microsoft.AspNetCore.Mvc;

namespace e_Ticaret.Order.WebApi.Controllers;

[Route("api/orderdetails")]
[ApiController]
public class OrderDetailsController : ControllerBase
{
    private readonly GetAllOrderDetailQueryHandler _getAllOrderDetailQueryHandler;
    private readonly GetOrderDetailByIdQueryHandler _getOrderDetailByIdQueryHandler;
    private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
    private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
    private readonly DeleteOrderDetailCommandHandler _deleteOrderDetailCommandHandler;

    public OrderDetailsController(GetAllOrderDetailQueryHandler getOrderDetailQueryHandler, GetOrderDetailByIdQueryHandler getOrderDetailByIdQueryHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, DeleteOrderDetailCommandHandler deleteOrderDetailCommandHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler)
    {
        _getAllOrderDetailQueryHandler = getOrderDetailQueryHandler;
        _getOrderDetailByIdQueryHandler = getOrderDetailByIdQueryHandler;
        _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
        _deleteOrderDetailCommandHandler = deleteOrderDetailCommandHandler;
        _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
    }
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        List<GetAllOrderDetailQueryResult> values = await _getAllOrderDetailQueryHandler.Handle();
        return Ok(values);
    }
    [HttpGet("{id}")]
    public async Task<IActionResult> GetOrderDetail(int id)
    {
        GetOrderDetailByIdQueryResult value = await _getOrderDetailByIdQueryHandler.Handle(new GetOrderDetailByIdQuery(id));
        return Ok(value);
    }
    [HttpPost]
    public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
    {
        await _createOrderDetailCommandHandler.Handle(createOrderDetailCommand);
        return Ok("Sipariş detayı başarıyla eklendi.");
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteOrderDetail(DeleteOrderDetailCommand deleteOrderDetailCommand)
    {
        await _deleteOrderDetailCommandHandler.Handle(deleteOrderDetailCommand);
        return Ok("Sipariş detayı başarıyla silindi.");
    }
    [HttpPut]
    public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
    {
        await _updateOrderDetailCommandHandler.Handle(updateOrderDetailCommand);
        return Ok("Sipariş detayı başarıyla güncellendi.");
    }
}
