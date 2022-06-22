using Microsoft.Extensions.DependencyInjection;
using ProductRegistration.Api.AutoMapper;
using ProductRegistration.Application.AutoMapper;

namespace ProductRegistration.Infra.CrossCutting.IoC.Configurations;

public static class ConfigurationMapper
{
    public static void Configuration(IServiceCollection service)
    {
        service.AddAutoMapper(x =>
        {
            x.AddProfile(new RequestToDto());
            x.AddProfile(new RequestToNotification());
            x.AllowNullCollections = true;
            x.AllowNullCollections = true;
        });
    }
}
