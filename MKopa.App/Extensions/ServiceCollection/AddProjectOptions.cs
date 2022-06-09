namespace MKopa.App.Extensions.ServiceCollection
{
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Options;

    using Data.Options;
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectOptions(this IServiceCollection @this, IConfiguration configuration) =>
            @this
                .Configure<AzureBusOption>(configuration.GetSection(nameof(AzureBusOption)))
                .AddSingleton(x => x.GetRequiredService<IOptions<AzureBusOption>>().Value);
    }
}
