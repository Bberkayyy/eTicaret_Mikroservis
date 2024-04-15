using e_Ticaret.Order.Application.Features.Mediator.Queries.OrderingQueries;
using e_Ticaret.Order.Application.Features.Mediator.Results.OrderingResults;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;
using MediatR;

namespace e_Ticaret.Order.Application.Features.Mediator.Handlers.OrderingHandlers;

public class GetAllOrderingQueryHandler : IRequestHandler<GetAllOrderingQuery, List<GetAllOrderingQueryResult>>
{
    private readonly IGenericRepository<Ordering> _repository;

    public GetAllOrderingQueryHandler(IGenericRepository<Ordering> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetAllOrderingQueryResult>> Handle(GetAllOrderingQuery request, CancellationToken cancellationToken)
    {
        IEnumerable<Ordering> values = await _repository.GetAllAsync();
        return values.Select(x => new GetAllOrderingQueryResult
        {
            Id = x.Id,
            UserId = x.UserId,
            TotalPrice = x.TotalPrice,
            OrderDate = x.OrderDate
        }).ToList();
    }
}
