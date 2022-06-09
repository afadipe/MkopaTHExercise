using System;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;
using Mkopa.Core.ServiceBusContracts;
using MKopa.Data.Options;

namespace MKopa.App.Extensions.ServiceCollection
{
    public static partial class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMessageBus(this IServiceCollection @this)
        {
            var azureBusOption = @this.BuildServiceProvider().GetService<AzureBusOption>();
            var azureServiceBus = Bus.Factory.CreateUsingAzureServiceBus(cfg =>
            {
                cfg.Host(azureBusOption.AzureServiceBusEndPoint);
                cfg.Message<SendSMSContract>(configTopology =>
                {
                    configTopology.SetEntityName(azureBusOption.SendSMSQueueName);
                });
            });


            @this.AddMassTransit(config =>
            {
                config.AddBus(provider => azureServiceBus);
            });

            @this.AddSingleton<ISendEndpointProvider>(azureServiceBus);
            @this.AddSingleton<IBus>(azureServiceBus);

            return @this;
        }
    }
}
