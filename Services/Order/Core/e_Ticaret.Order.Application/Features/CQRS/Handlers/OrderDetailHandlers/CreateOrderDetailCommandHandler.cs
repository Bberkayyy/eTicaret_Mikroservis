using e_Ticaret.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class CreateOrderDetailCommandHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;

    public CreateOrderDetailCommandHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task Handle(CreateOrderDetailCommand createOrderDetailCommand)
    {
        await _repository.CreateAsync(new OrderDetail
        {
            OrderingId = createOrderDetailCommand.OrderingId,
            ProductId = createOrderDetailCommand.ProductId,
            ProductName = createOrderDetailCommand.ProductName,
            ProductAmount = createOrderDetailCommand.ProductAmount,
            ProductUnitPrice = createOrderDetailCommand.ProductUnitPrice,
            ProductTotalPrice = createOrderDetailCommand.ProductAmount * createOrderDetailCommand.ProductUnitPrice
        });
    }
}
