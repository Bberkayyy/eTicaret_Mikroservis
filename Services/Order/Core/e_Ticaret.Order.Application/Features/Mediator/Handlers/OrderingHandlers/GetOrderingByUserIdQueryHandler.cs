using e_Ticaret.Order.Application.Features.Mediator.Queries.OrderingQueries;
using e_Ticaret.Order.Application.Features.Mediator.Results.OrderingResults;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;
using MediatR;

namespace e_Ticaret.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetOrderingByUserIdQueryHandler : IRequestHandler<GetOrderingByUserIdQuery, List<GetOrderingByUserIdQueryResult>>
{
    private readonly IGenericRepository<Ordering> _repository;

    public GetOrderingByUserIdQueryHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetOrderingByUserIdQueryResult>> Handle(GetOrderingByUserIdQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Ordering> values = await _repository.GetAllAsync(x => x.UserId == request.UserId);
        return values.Select(x => new GetOrderingByUserIdQueryResult
        {
            Id = x.Id,
            UserId = x.UserId,
            OrderDate = x.OrderDate,
            TotalPrice = x.TotalPrice
        }).ToList();
    }
}
