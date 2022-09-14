using System.Text.Json;
using MediatR;
using ProductRegistration.Notification.SNS;
using ProductRegistration.Shared.Configs;
using Serilog;

namespace ProductRegistration.Application.Events.Products.UpdateHandler;

public class ProductEventUpdateHandler : INotificationHandler<ProductNotificationUpdate>
{
    private readonly ILogger _log;
    private readonly ISnsNotificationClient _snsNotificationClient;
    private readonly NotificationEventProductionConfig _notificationEventProductionConfig;

    public ProductEventUpdateHandler(ILogger log,
                                     ISnsNotificationClient snsNotificationClient,
                                     NotificationEventProductionConfig notificationEventProductionConfig)
    {
        _log = log;
        _snsNotificationClient = snsNotificationClient;
        _notificationEventProductionConfig = notificationEventProductionConfig;
    }

    public Task Handle(ProductNotificationUpdate notification, CancellationToken cancellationToken)
    {
        _log.Information("Notificando");

        var valueSerialization = JsonSerializer.Serialize(notification);
        _snsNotificationClient.Send(_notificationEventProductionConfig.ArnSnsUpdateProduct ?? "", 
                                    _notificationEventProductionConfig.SubjectUpdateProduct ?? "",
                                    valueSerialization);

        _log.Information("Notificado");
        return Task.CompletedTask;
    }
}