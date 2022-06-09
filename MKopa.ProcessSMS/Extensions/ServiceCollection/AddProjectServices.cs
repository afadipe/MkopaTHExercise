namespace MKopa.ProcessSMS.Extensions.ServiceCollection
{
    using MediatR;
    using Microsoft.Extensions.DependencyInjection;
    using System.Reflection;
    using Mkopa.Core.Applications.Commands;
    using Mkopa.Core.AutoMapperProfile;
    using Mkopa.Core.Services.Interfaces;
    using Mkopa.Core.Services.Implementations;
    using System;
    using Microsoft.Extensions.Hosting;

    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddProjectServices(this IServiceCollection @this) =>
           @this
                .AddAutoMapper(typeof(MapperProfile))
                .AddScoped<IProcessSMS, ProcessSMS>()
                .AddScoped<ISMSProvider, NGNProvider>()
                .AddScoped<ISMSCurrentProvider, SMSCurrentProvider>();
    }
}
