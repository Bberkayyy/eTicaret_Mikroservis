using e_Ticaret.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
using e_Ticaret.Order.Application.Features.CQRS.Results.OrderDetailResults;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetOrderDetailByIdQueryHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;

    public GetOrderDetailByIdQueryHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDetailByIdQuery getOrderDetailByIdQuery)
    {
        OrderDetail value = await _repository.GetByIdAsync(getOrderDetailByIdQuery.Id);
        return new GetOrderDetailByIdQueryResult
        {
            Id = value.Id,
            OrderingId = value.OrderingId,
            ProductId = value.ProductId,
            ProductName = value.ProductName,
            ProductAmount = value.ProductAmount,
            ProductUnitPrice = value.ProductUnitPrice,
            ProductTotalPrice = value.ProductTotalPrice
        };
    }
}
