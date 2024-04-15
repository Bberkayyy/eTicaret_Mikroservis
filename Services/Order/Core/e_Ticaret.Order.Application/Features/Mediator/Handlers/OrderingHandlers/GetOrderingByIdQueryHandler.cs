using e_Ticaret.Order.Application.Features.Mediator.Queries.OrderingQueries;
using e_Ticaret.Order.Application.Features.Mediator.Results.OrderingResults;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;
using MediatR;

namespace e_Ticaret.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByIdQueryHandler : IRequestHandler<GetOrderingByIdQuery, GetOrderingByIdQueryResult>
{
    private readonly IGenericRepository<Ordering> _repository;

    public GetOrderingByIdQueryHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<GetOrderingByIdQueryResult> Handle(GetOrderingByIdQuery request, CancellationToken cancellationToken)
    {
        Ordering value = await _repository.GetByIdAsync(request.Id);
        return new GetOrderingByIdQueryResult
        {
            Id = request.Id,
            UserId = value.UserId,
            TotalPrice = value.TotalPrice,
            OrderDate = value.OrderDate,
        };
    }
}
