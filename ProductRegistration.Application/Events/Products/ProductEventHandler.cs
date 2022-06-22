using MediatR;
using Serilog;

namespace ProductRegistration.Application.Events.Products;

public class ProductEventHandler : INotificationHandler<ProductNotification>
{
    private readonly ILogger _log;

    public ProductEventHandler(ILogger log)
    {
        _log = log;
    }

    public Task Handle(ProductNotification notification, CancellationToken cancellationToken)
    {
        _log.Information("Notificado");
        return Task.CompletedTask;
    }
}