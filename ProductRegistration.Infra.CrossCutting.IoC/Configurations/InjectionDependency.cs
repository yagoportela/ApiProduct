using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductRegistration.Infra.CrossCutting.IoC.Configurations;
public class InjectionDependency
{
    public static void Injection(IServiceCollection services)
    {
        LoggerService.ConfigurationSerilog(services);
        ConfigurationApiVerions.Configure(services);
        ConfigurationSettings.ConfigurationEnvironment(services);
        DependencyServices.ConfigurationDependences(services);
        InjectionMediatr.Injection(services);
        InjectionFluent.Injection(services);
        ConfigurationMapper.Configuration(services);
        ConfigurationSwagger.Configure(services);
        InjectionAWS.Injection(services);
    }

}
