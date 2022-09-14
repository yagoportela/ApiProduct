using System.Text.Json;
using MediatR;
using ProductRegistration.Notification.SNS;
using ProductRegistration.Shared.Configs;
using Serilog;

namespace ProductRegistration.Application.Events.Products.CreateHandler;

public class ProductEventCreateHandler : INotificationHandler<ProductNotificationCreate>
{
    private readonly ILogger _log;
    private readonly ISnsNotificationClient _snsNotificationClient;
    private readonly NotificationEventProductionConfig _notificationEventProductionConfig;

    public ProductEventCreateHandler(ILogger log,
                                     ISnsNotificationClient snsNotificationClient,
                                     NotificationEventProductionConfig notificationEventProductionConfig)
    {
        _log = log;
        _snsNotificationClient = snsNotificationClient;
        _notificationEventProductionConfig = notificationEventProductionConfig;
    }

    public Task Handle(ProductNotificationCreate notification, CancellationToken cancellationToken)
    {
        _log.Information("Notificando");

        var valueSerialization = JsonSerializer.Serialize(notification);
        _snsNotificationClient.Send(_notificationEventProductionConfig.ArnSnsRegistration ?? "", 
                                    _notificationEventProductionConfig.SubjectRegistration ?? "",
                                    valueSerialization);

        _log.Information("Notificado");
        return Task.CompletedTask;
    }
}