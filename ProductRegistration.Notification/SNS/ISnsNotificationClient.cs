namespace ProductRegistration.Notification.SNS;

public interface ISnsNotificationClient
{
    Task<string?> Send(string topic, string subject, string message);
}
