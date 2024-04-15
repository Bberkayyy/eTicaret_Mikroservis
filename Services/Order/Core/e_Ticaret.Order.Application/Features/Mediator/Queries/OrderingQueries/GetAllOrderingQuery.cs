using e_Ticaret.Order.Application.Features.Mediator.Results.OrderingResults;
using MediatR;

namespace e_Ticaret.Order.Application.Features.Mediator.Queries.OrderingQueries;

public class GetAllOrderingQuery : IRequest<List<GetAllOrderingQueryResult>>
{
}
