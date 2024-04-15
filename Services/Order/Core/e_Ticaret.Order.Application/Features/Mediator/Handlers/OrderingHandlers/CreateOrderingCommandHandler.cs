using e_Ticaret.Order.Application.Features.Mediator.Commands.OrderingCommands;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;
using MediatR;

namespace e_Ticaret.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand>
{
    private readonly IGenericRepository<Ordering> _repository;

    public CreateOrderingCommandHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
    {
        await _repository.CreateAsync(new Ordering
        {
            UserId = request.UserId,
            TotalPrice = request.TotalPrice,
            OrderDate = request.OrderDate,
        });
    }
}
