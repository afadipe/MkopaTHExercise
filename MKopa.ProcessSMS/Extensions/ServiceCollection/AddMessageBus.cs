using System;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using MKopa.Data.Options;
using MKopa.ProcessSMS.Consumers;

namespace MKopa.ProcessSMS.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection @this)
        {
            var azureBusOption = @this.BuildServiceProvider().GetService<AzureBusOption>();
            @this.AddMassTransit(configurator =>
            {
                configurator.AddConsumer<ProcessSMSConsumer>();
                configurator.AddBus(provider => Bus.Factory.CreateUsingAzureServiceBus(cfg =>
                {
                    cfg.Host(azureBusOption.AzureServiceBusEndPoint);
                    cfg.UseJsonSerializer();
                    cfg.ReceiveEndpoint(azureBusOption.SendSMSQueueName, e =>
                    {
                        e.ConfigureConsumer<ProcessSMSConsumer>(provider);
                    });
                    cfg.UseServiceBusMessageScheduler();
                }));
            });
            return @this;
        }
    }
}
