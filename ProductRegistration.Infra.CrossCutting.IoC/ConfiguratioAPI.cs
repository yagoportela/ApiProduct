using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using ProductRegistration.Infra.CrossCutting.IoC.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProductRegistration.Infra.CrossCutting.IoC;

public class ConfiguratioAPI
{
    public static void Configure(IServiceCollection services)
    {
        services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();
        services.AddEndpointsApiExplorer();

        services.AddControllers()
            .AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
            });
        services.AddSwaggerGen(
             options =>
             {
                 options.OperationFilter<SwaggerDefaultValues>();
             });
    }
}
