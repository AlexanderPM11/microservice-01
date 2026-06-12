using Microsoft.OpenApi;

namespace microservice_01.Modules.Swagger
{
    public static class SwaggerExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                // Created the Swagger document
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "Version .Net 10",
                    Title = "Swagger UI Personalized .Net 10",
                    Description = " Thanks for sharing.",
                    TermsOfService = new Uri("https://cvmendozacr.com/"),
                    Contact = new OpenApiContact
                    {
                        Name = "Ing. Alexander Polanco",
                        Url = new Uri("https://apolanco.com")
                    },

                    License = new OpenApiLicense
                    {
                        Name = "For capacitation and reference use.",
                        Url = new Uri("https://example.com/license")
                    }
                });

                // form 2 to generate the swagger documentation
                foreach (var name in Directory.GetFiles(AppContext.BaseDirectory, "*.XML", SearchOption.TopDirectoryOnly))
                {
                    c.IncludeXmlComments(filePath: name);
                }

                // second form to give Authorization without writing the word Bearer
                var securityScheme = new OpenApiSecurityScheme()
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT" // Optional
                };

                c.AddSecurityDefinition("bearerAuth", securityScheme);

                c.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                     {
                          new OpenApiSecuritySchemeReference("bearerAuth", document),
                          new List<string>()
                     }
                });

            });

            return services;
        } 
    }
}
