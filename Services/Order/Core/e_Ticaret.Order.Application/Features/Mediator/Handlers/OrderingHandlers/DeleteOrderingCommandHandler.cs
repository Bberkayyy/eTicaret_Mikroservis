using e_Ticaret.Order.Application.Features.Mediator.Commands.OrderingCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;
using MediatR;

namespace e_Ticaret.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class DeleteOrderingCommandHandler : IRequestHandler<DeleteOrderingCommand>
{
    private readonly IGenericRepository<Ordering> _repository;

    public DeleteOrderingCommandHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(DeleteOrderingCommand request, CancellationToken cancellationToken)
    {
        Ordering value = await _repository.GetByFilterAsync(x => x.Id == request.Id);
        await _repository.DeleteAsync(value);
    }
}
