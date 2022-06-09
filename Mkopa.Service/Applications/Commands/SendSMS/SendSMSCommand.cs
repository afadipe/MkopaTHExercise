using MediatR;
using Mkopa.Core.DTO;

namespace Mkopa.Core.Applications.Commands
{
    public class SendSMSCommand : IRequest<APIResponseModel<string>>
    {
        public SendSMSDto Model { get; }
        public SendSMSCommand(SendSMSDto model)
        {
            Model = model;
        }
    }
}
