using e_Ticaret.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class UpdateOrderDetailCommandHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;

    public UpdateOrderDetailCommandHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task Handle(UpdateOrderDetailCommand updateOrderDetailCommand)
    {
        OrderDetail value = await _repository.GetByFilterAsync(x => x.Id == updateOrderDetailCommand.Id);
        value.OrderingId = updateOrderDetailCommand.OrderingId;
        value.ProductId = updateOrderDetailCommand.ProductId;
        value.ProductName = updateOrderDetailCommand.ProductName;
        value.ProductUnitPrice = updateOrderDetailCommand.ProductUnitPrice;
        value.ProductAmount = updateOrderDetailCommand.ProductAmount;
        value.ProductTotalPrice = updateOrderDetailCommand.ProductUnitPrice * updateOrderDetailCommand.ProductAmount;
        await _repository.UpdateAsync(value);
    }
}
