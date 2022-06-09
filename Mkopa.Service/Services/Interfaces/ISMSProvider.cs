using Mkopa.Core.DTO;
using Mkopa.Core.ServiceBusContracts;
using System.Net;
using System.Threading.Tasks;

namespace Mkopa.Core.Services.Interfaces
{
    public interface ISMSProvider
    {
        Task<SMSProviderResponse> SendSMS(SendSMSContract payload);
    }
}
