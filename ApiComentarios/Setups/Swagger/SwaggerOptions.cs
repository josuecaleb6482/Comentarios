using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;

namespace ApiComentarios.WebApi.Setups.Swagger
{
    public class SwaggerOptions : IConfigureOptions<SwaggerGenOptions>
    {
        readonly IApiVersionDescriptionProvider provider;
        /// <summary>
        /// Initializes a new instance of the <see cref="SwaggerOptions"/> class.
        /// </summary>
        /// <param name="provider">The <see cref="IApiVersionDescriptionProvider">provider</see> used to 
        public SwaggerOptions(IApiVersionDescriptionProvider provider) => this.provider = provider;
        public void Configure(SwaggerGenOptions options)
        {
            foreach (var description in provider.ApiVersionDescriptions)
                options.SwaggerDoc(description.GroupName, CreateInfoForApiVersion(description));
        }

        static OpenApiInfo CreateInfoForApiVersion(ApiVersionDescription description)
        {
            var info = new OpenApiInfo()
            {
                Title = "Api Comentarios",
                Version = description.ApiVersion.ToString(),
                Description = "Ejemplo descriptivo para la monografia",
                Contact = new OpenApiContact() { Name = "Josue Florez", Email = "josue.florez@utp.ac.pa", Url = new Uri("https://utp.ac.pa") }
            };

            if (description.IsDeprecated)
            {
                info.Description = $"{info.Description} Esta version API esta obsoleta.";
            }

            return info;
        }
    }
}
