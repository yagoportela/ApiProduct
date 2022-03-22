using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProductRegistration.Infra.CrossCutting.IoC.Middleware;

namespace ProductRegistration.Infra.CrossCutting.IoC
{
    public static class ConfigurationBuild
    {
        public static void Configuration(WebApplication app)
        {
            app.UseExceptionMiddleware();
            ConfigurationSwagger(app);
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
            // app.UseHttpsRedirection();
        }

        private static void ConfigurationSwagger(WebApplication app)
        {
            var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    foreach (var description in apiVersionDescriptionProvider.ApiVersionDescriptions.Reverse())
                    {
                        c.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json",
                            description.GroupName.ToUpperInvariant());
                    };
                });
            }
        }
    }
}