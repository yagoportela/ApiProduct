using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using ProductRegistration.Shared.Configs;
using Serilog;

namespace ProductRegistration.Notification.SNS;

public class SnsNotificationClient : ISnsNotificationClient
{
    private readonly IAmazonSimpleNotificationService _clientSNS;
    private readonly ILogger _log;
    private readonly NotificationConfig _notificationConfig;

    public SnsNotificationClient(IAmazonSimpleNotificationService clientSNS,
                                 ILogger log,
                                 NotificationConfig notificationConfig)
    {
        _clientSNS = clientSNS;
        _log = log;
        _notificationConfig = notificationConfig;
    }

    public async Task<string?> Send(string topic, string subject, string message)
    {
        if (!_notificationConfig.Disparar)
            return null;

        ValidateValues(topic, subject, message);
        return await PublicMessage(topic, subject, message);
    }

    private static void ValidateValues(string topic, string subject, string message)
    {
        if (topic == null) throw new ArgumentNullException(nameof(topic));
        if (subject == null) throw new ArgumentNullException(nameof(subject));
        if (message == null) throw new ArgumentNullException(nameof(message));
    }

    private async Task<string> PublicMessage(string topic, string subject, string message)
    {
        var request = new PublishRequest(topic, message, $"{_notificationConfig.Ambiente} - {subject}");
        var response = await _clientSNS.PublishAsync(request);

        return response.MessageId;
    }
}