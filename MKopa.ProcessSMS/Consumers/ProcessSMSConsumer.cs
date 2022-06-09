using MassTransit;
using MassTransit.Mediator;
using Microsoft.Extensions.Logging;
using Mkopa.Core.Applications.Commands;
using Mkopa.Core.ServiceBusContracts;
using Mkopa.Core.Services.Interfaces;
using System.Threading.Tasks;

namespace MKopa.ProcessSMS.Consumers
{
    public class ProcessSMSConsumer : IConsumer<SendSMSContract>
    {
        private readonly ILogger<ProcessSMSConsumer> _logger;
        private readonly IProcessSMS _processSMS;
        public ProcessSMSConsumer(ILogger<ProcessSMSConsumer> logger, IProcessSMS processSMS)
        {
            _logger = logger;
            _processSMS = processSMS;
        }

        public async Task Consume(ConsumeContext<SendSMSContract> context)
        {
            await _processSMS.Process(context.Message);
        }
    }
}
