using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace ProductRegistration.Infra.CrossCutting.IoC.Swagger;
public class ConfigureSwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConfigureSwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to generate Swagger documents.</param>
        public ConfigureSwaggerOptions( IApiVersionDescriptionProvider provider ) => this.provider = provider;

        /// <inheritdoc />
        public void Configure( SwaggerGenOptions options )
        {
            foreach ( var description in provider.ApiVersionDescriptions )
            {
                options.SwaggerDoc( description.GroupName, CreateInfoForApiVersion( description ) );
            }
        }

        static OpenApiInfo CreateInfoForApiVersion( ApiVersionDescription description )
        {
            var info = new OpenApiInfo()
            {
                Title = "Sample API",
                Version = description.ApiVersion.ToString(),
                Description = "A sample application with Swagger, Swashbuckle, and API versioning.",
                Contact = new OpenApiContact() { Name = "Not Contact", Email = "https://opensource.org/licenses/MIT" },
            };

            if ( description.IsDeprecated )
            {
                info.Description += " This API version has been deprecated.";
            }

            return info;
        }
    }