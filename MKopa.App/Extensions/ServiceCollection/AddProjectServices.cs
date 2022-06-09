namespace MKopa.App.Extensions.ServiceCollection
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using Mkopa.Core.AutoMapperProfile;
    using Mkopa.Core.Applications.Commands;

    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection @this) =>
           @this
                .AddMediatR(typeof(SendSMSCommand).GetTypeInfo().Assembly)
                .AddAutoMapper(typeof(MapperProfile));
    }
}
