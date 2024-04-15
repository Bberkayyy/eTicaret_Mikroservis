using e_Ticaret.Order.Application.Features.CQRS.Results.OrderDetailResults;
using e_Ticaret.Order.Application.Interfaces;
using e_Ticaret.Order.Domain.Entities;

namespace e_Ticaret.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;

public class GetAllOrderDetailQueryHandler
{
    private readonly IGenericRepository<OrderDetail> _repository;

    public GetAllOrderDetailQueryHandler(IGenericRepository<OrderDetail> repository)
    {
        _repository = repository;
    }
    public async Task<List<GetAllOrderDetailQueryResult>> Handle()
    {
        IEnumerable<OrderDetail> values = await _repository.GetAllAsync();
        return values.Select(x => new GetAllOrderDetailQueryResult
        {
            Id = x.Id,
            OrderingId = x.OrderingId,
            ProductId = x.ProductId,
            ProductName = x.ProductName,
            ProductUnitPrice = x.ProductUnitPrice,
            ProductAmount = x.ProductAmount,
            ProductTotalPrice = x.ProductTotalPrice,
        }).ToList();
    }
}
