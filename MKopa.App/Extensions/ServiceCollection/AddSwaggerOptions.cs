namespace MKopa.App.Extensions.ServiceCollection
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.OpenApi.Models;
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwaggerOptions(this IServiceCollection @this) =>
            @this.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Mkopa APP API",
                    Description = "Use this API for messaging",
                    Contact = new OpenApiContact
                    {
                        Name = "Mkopa ",
                        Email = "support@mkopa.com",
                    },

                });;
            });
    }
}
