using Microsoft.Extensions.DependencyInjection;
using ProductRegistration.Application.AutoMapper;

namespace ProductRegistration.Infra.CrossCutting.IoC
{
    public static class ConfigurationMapper
    {
        public static void Configuration(IServiceCollection service)
        {
            service.AddAutoMapper(x => 
            {
                x.AddProfile(new RequestToDto());
                x.AllowNullCollections = true;
                x.AllowNullCollections = true;
            });
        }
    }
}