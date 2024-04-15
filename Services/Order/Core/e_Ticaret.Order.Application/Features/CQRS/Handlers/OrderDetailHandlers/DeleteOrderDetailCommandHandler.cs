using e_Ticaret.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class DeleteOrderDetailCommandHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;

    public DeleteOrderDetailCommandHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task Handle(DeleteOrderDetailCommand deleteOrderDetailCommand)
    {
        OrderDetail value = await _repository.GetByFilterAsync(x => x.Id == deleteOrderDetailCommand.Id);
        await _repository.DeleteAsync(value);
    }
}
