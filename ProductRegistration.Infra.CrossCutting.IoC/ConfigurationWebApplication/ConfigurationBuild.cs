using Microsoft.AspNetCore.Builder;
using ProductRegistration.Infra.CrossCutting.IoC.Middleware;

namespace ProductRegistration.Infra.CrossCutting.IoC.ConfigurationWebApplication;

public static class ConfigurationBuild
{
    public static void Configuration(WebApplication app)
    {
        app.UseExceptionMiddleware();
        AppSwagger.ConfigurationSwagger(app);

        app.UseAuthorization();
        app.MapControllers();
        app.Run();
        // app.UseHttpsRedirection();
    }
}