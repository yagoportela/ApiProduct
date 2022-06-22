using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace ProductRegistration.Infra.CrossCutting.IoC.Configurations;

public class LoggerService
{
    public static void ConfigurationSerilog(IServiceCollection services)
    {
        services.AddSingleton((ILogger) new LoggerConfiguration()
                                        .MinimumLevel.Information()
                                        .WriteTo.Console()
                                        .CreateLogger());
    }    
}