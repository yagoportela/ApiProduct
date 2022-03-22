using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace ProductRegistration.Infra.CrossCutting.IoC;
public static class InjectionMediatr
{
    public static void Injection(IServiceCollection services)
    {
        var assembly = AppDomain.CurrentDomain.Load("ProductRegistration.Application");
        services.AddMediatR(assembly);
    }
}