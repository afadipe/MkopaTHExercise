using Azure.Messaging.ServiceBus;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mkopa.Core.DTO;
using Mkopa.Core.ServiceBusContracts;
using Mkopa.Core.Services.Interfaces;
using MKopa.Data.Options;
using Newtonsoft.Json;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mkopa.Core.Applications.Commands
{
    public class ProcessSMS : IProcessSMS
    {
        private readonly ISMSCurrentProvider _smsProvider;
        private readonly ILogger<ProcessSMS> _logger;
        private readonly AzureBusOption _azureBusOptions;

        public ProcessSMS(ILogger<ProcessSMS> logger,
            IOptions<AzureBusOption> azureBusOptions, ISMSCurrentProvider smsProvider)
        {
            _logger = logger;
            _azureBusOptions = azureBusOptions.Value;
            _smsProvider = smsProvider;
        }
        public async Task<APIResponseModel<string>> Process(SendSMSContract model)
        {
            try
            {
                var smsProvider = _smsProvider.GetCurrentSMSProvider(model.PhoneNumber);
                var response = await smsProvider.SendSMS(model);
                if(response.Code == System.Net.HttpStatusCode.OK)
                {
                    var contractModel = new ProcessedSMSContract
                    {
                        Code = response.Code,
                        SmsText = model.SmsText,
                        PhoneNumber = model.PhoneNumber,
                        Provider = response.Provider,
                        ProviderMessdageId = response.ProviderMessdageId
                    };
                    await SendGlobalMessage(JsonConvert.SerializeObject(contractModel));
                }
                var result = $"Processed SMS with Phone number {model.PhoneNumber}";
                _logger.LogInformation(result);
                return WebApiResponses<string>.Successful(result);
            }
            catch (Exception ex)
            {
                return WebApiResponses<string>.ErrorOccured("An error occurred while rocessing your request");
            }

           
        }

        public async Task SendGlobalMessage(string payloadMessage)
        {
            try
            {
                // since ServiceBusClient implements IAsyncDisposable we create it with "await using"
                await using var client = new ServiceBusClient(_azureBusOptions.AzureServiceBusEndPoint);

                // create the sender
                ServiceBusSender sender = client.CreateSender(_azureBusOptions.ProcessedSMSQueueName);

                // create a message that we can send. UTF-8 encoding is used when providing a string.
                ServiceBusMessage message = new ServiceBusMessage(payloadMessage);

                // send the message
                await sender.SendMessageAsync(message);
            }
            catch 
            {
            }
        }
    }
}
