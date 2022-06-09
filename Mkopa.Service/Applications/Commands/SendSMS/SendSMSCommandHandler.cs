using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mkopa.Core.DTO;
using Mkopa.Core.ServiceBusContracts;
using MKopa.Data.Options;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Mkopa.Core.Applications.Commands
{
    public class SendSMSCommandHandler : IRequestHandler<SendSMSCommand, APIResponseModel<string>>
    {
        private readonly ILogger<SendSMSCommandHandler> _logger;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        private readonly AzureBusOption _azureBusOptions;
        private readonly IMapper _mapper;

        public SendSMSCommandHandler(ILogger<SendSMSCommandHandler> logger, ISendEndpointProvider sendEndpointProvider, 
            IOptions<AzureBusOption> azureBusOptions, IMapper mapper)
        {
            _logger = logger;
            _sendEndpointProvider = sendEndpointProvider;
            _azureBusOptions = azureBusOptions.Value;
            _mapper = mapper;
        }

        public async Task<APIResponseModel<string>> Handle(SendSMSCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var model = _mapper.Map<SendSMSContract>(request.Model);
                var endpoint =
               await _sendEndpointProvider.GetSendEndpoint(
                   new Uri($"{_azureBusOptions.AzureServiceBusBaseURL}{_azureBusOptions.SendSMSQueueName}"));
                await endpoint.Send(model, cancellationToken);
                var result = $"Send SMS Command with Phone number {request.Model.PhoneNumber}";
                _logger.LogInformation(result);
                return WebApiResponses<string>.Successful(result);
            }
            catch (Exception ex)
            {
                return WebApiResponses<string>.ErrorOccured("An error occurred while rocessing your request");
            }
           
        }
    }
}
