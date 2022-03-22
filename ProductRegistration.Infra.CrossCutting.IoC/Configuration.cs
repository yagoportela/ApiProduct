using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ProductRegistration.Infra.CrossCutting.IoC;

public static class ConfigurationSettings
{
    public static void ConfigurationEnvironment(IServiceCollection services)
    {
        var configuration = GetConfiguration();

        // services.AddSingleton<object> (Configuration.GetConfiguration()
        //                                                     .GetSection("bdCadastro")
        //                                                     .Get<object>());
    }
    
    private static IConfiguration GetConfiguration () =>
        new ConfigurationBuilder()
            .SetBasePath (Directory.GetCurrentDirectory ())
            .AddJsonFile ("appsettings.json", optional : true, reloadOnChange : true)
            .AddJsonFile ("AWS_REGION", optional : true, reloadOnChange : true)
            .AddEnvironmentVariables ()
            .Build ();
}