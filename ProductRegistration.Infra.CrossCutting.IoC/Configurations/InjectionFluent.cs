using System.Reflection;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace ProductRegistration.Infra.CrossCutting.IoC.Configurations;

public class InjectionFluent
{
    public static void Injection(IServiceCollection services)
    {
        services.AddControllers()
            .AddFluentValidation(fv =>
            {
                fv.DisableDataAnnotationsValidation = true;
            });
        services.AddValidatorsFromAssembly(Assembly.Load("ProductRegistration.Application"));
    }
}