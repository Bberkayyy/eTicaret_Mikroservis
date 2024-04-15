using e_Ticaret.Order.Application.Features.CQRS.Handlers.AddressHandlers;
using e_Ticaret.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using e_Ticaret.Order.Application.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace e_Ticaret.Order.Application.ServiceReigstrations;

public static class OrderDependencies
{
    public static IServiceCollection AddOrderDependencies(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<GetAllAddressQueryHandler>();
        services.AddScoped<GetAddressByIdQueryHandler>();
        services.AddScoped<CreateAddressCommandHandler>();
        services.AddScoped<UpdateAddressCommandHandler>();
        services.AddScoped<DeleteAddressCommandHandler>();

        services.AddScoped<GetAllOrderDetailQueryHandler>();
        services.AddScoped<GetOrderDetailByIdQueryHandler>();
        services.AddScoped<CreateOrderDetailCommandHandler>();
        services.AddScoped<UpdateOrderDetailCommandHandler>();
        services.AddScoped<DeleteOrderDetailCommandHandler>();

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        return services;
    }
}