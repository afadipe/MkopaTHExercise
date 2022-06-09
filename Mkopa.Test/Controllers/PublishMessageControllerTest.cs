using AutoMapper;
using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Mkopa.Core.Applications.Commands;
using Mkopa.Core.DTO;
using MKopa.App.Controllers;
using MKopa.Data.Options;
using Moq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Mkopa.Test.Controllers
{
    public class PublishMessageControllerTest
    {
        private readonly Mock<IMediator> _mediator;
        private readonly Mock<ILogger<PublishMessageController>> _loggerMock;
        private readonly SendSMSCommandHandler _createCommandHandler;
        private readonly ISendEndpointProvider _sendEndpointProvider;
        public PublishMessageControllerTest()
        {
            _mediator = new Mock<IMediator>();
            _loggerMock = new Mock<ILogger<PublishMessageController>>();
            _sendEndpointProvider = Mock.Of<ISendEndpointProvider>();
            _createCommandHandler = new SendSMSCommandHandler(new Mock<ILogger<SendSMSCommandHandler>>().Object, _sendEndpointProvider, Mock.Of<IOptions<AzureBusOption>>(), Mock.Of<IMapper>());
        }

        [Fact]
        public async Task OrderHandler_Should_Throw_Error_When_subService_Not_Mocked()
        {
            var model = new SendSMSDto
            {
                PhoneNumber = "793232323",
                SmsText = "Text"
            };
            var result = await _createCommandHandler.Handle(new SendSMSCommand(model), new CancellationToken());
            Assert.NotNull(result.Message);
            Assert.Equal("An error occurred while processing your request!", result.Message);
        }
    }
}
