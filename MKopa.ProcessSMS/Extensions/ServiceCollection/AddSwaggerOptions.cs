namespace MKopa.ProcessSMS.Extensions.ServiceCollection
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
                    Title = "MKopa Process SMS micro API",
                    Description = "Use this API for Processing messages",
                    Contact = new OpenApiContact
                    {
                        Name = "Mkopa ",
                        Email = "support@mkopa.com",
                    },

                });;
            });
    }
}
