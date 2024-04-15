using e_Ticaret.Order.Application.Features.Mediator.Commands.OrderingCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;
using MediatR;

namespace e_Ticaret.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class UpdateOrderingCommandHandler : IRequestHandler<UpdateOrderingCommand>
{
    private readonly IGenericRepository<Ordering> _repository;

    public UpdateOrderingCommandHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(UpdateOrderingCommand request, CancellationToken cancellationToken)
    {
        Ordering value = await _repository.GetByFilterAsync(x => x.Id == request.Id);
        value.UserId = request.UserId;
        value.TotalPrice = request.TotalPrice;
        value.OrderDate = request.OrderDate;
        await _repository.UpdateAsync(value);
    }
}
