using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using Microsoft.Extensions.DependencyInjection;

namespace ProductRegistration.Infra.CrossCutting.IoC.Configurations;

public static class InjectionAWS
{
    public static void Injection(IServiceCollection services)
    {
        InjectionSNS(services);
    }

    private static void InjectionSNS(IServiceCollection services)
    {
        RegionEndpoint region = RegionEndpoint.USEast1;
        IAmazonSimpleNotificationService snsClient = new AmazonSimpleNotificationServiceClient(region);
        services.AddSingleton(snsClient);
    }
}