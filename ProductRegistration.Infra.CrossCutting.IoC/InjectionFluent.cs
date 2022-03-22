using System.Reflection;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace ProductRegistration.Infra.CrossCutting.IoC;
public class InjectionFluent
{
    public static void Injection(IServiceCollection services)
    {
        services.AddValidatorsFromAssembly(Assembly.Load("ProductRegistration.Application"));
    }
}