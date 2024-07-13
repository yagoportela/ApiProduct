using Microsoft.Extensions.DependencyInjection;
using ProductRegistration.Infra.CrossCutting.IoC.Configurations.Swagger;

namespace ProductRegistration.Infra.CrossCutting.IoC.Configurations;

public class ConfigurationSwagger
{
    public static void Configure(IServiceCollection services)
    {
        services.AddSwaggerGen();
        services.ConfigureOptions<ConfigureSwaggerOptions>();
    }
}