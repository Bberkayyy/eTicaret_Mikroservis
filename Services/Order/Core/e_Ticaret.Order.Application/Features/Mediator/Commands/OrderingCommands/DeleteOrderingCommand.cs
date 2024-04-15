using MediatR;

namespace e_Ticaret.Order.Application.Features.Mediator.Commands.OrderingCommands;

public class DeleteOrderingCommand : IRequest
{
    public int Id { get; set; }

    public DeleteOrderingCommand(int id)
    {
        Id = id;
    }
}
