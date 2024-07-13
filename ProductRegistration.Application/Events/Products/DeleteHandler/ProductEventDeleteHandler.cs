using System.Text.Json;
using MediatR;
using ProductRegistration.Notification.SNS;
using ProductRegistration.Shared.Configs;
using Serilog;

namespace ProductRegistration.Application.Events.Products.DeleteHandler;

public class ProductEventDeleteHandler : INotificationHandler<ProductNotificationDelete>
{
    private readonly ILogger _log;
    private readonly ISnsNotificationClient _snsNotificationClient;
    private readonly NotificationEventProductionConfig _notificationEventProductionConfig;

    public ProductEventDeleteHandler(ILogger log,
                                     ISnsNotificationClient snsNotificationClient,
                                     NotificationEventProductionConfig notificationEventProductionConfig)
    {
        _log = log;
        _snsNotificationClient = snsNotificationClient;
        _notificationEventProductionConfig = notificationEventProductionConfig;
    }

    public Task Handle(ProductNotificationDelete notification, CancellationToken cancellationToken)
    {
        _log.Information("Notificando");

        var valueSerialization = JsonSerializer.Serialize(notification);
        _snsNotificationClient.Send(_notificationEventProductionConfig.ArnSnsDeleteProduct ?? "", 
                                    _notificationEventProductionConfig.SubjectDeleteProduct ?? "",
                                    valueSerialization);

        _log.Information("Notificado");
        return Task.CompletedTask;
    }
}