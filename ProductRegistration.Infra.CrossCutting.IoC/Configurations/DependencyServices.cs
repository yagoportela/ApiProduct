using Microsoft.Extensions.DependencyInjection;
using ProductRegistration.Notification.SNS;

namespace ProductRegistration.Infra.CrossCutting.IoC.Configurations;

public class DependencyServices
{
    public static void ConfigurationDependences(IServiceCollection services)
    {
        ConfigurationNotification(services);
    }

    public static void ConfigurationNotification(IServiceCollection services)
    {
        services.AddSingleton<ISnsNotificationClient, ISnsNotificationClient>();
    }
}