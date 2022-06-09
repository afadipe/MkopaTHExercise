using Mkopa.Core.DTO;
using Mkopa.Core.ServiceBusContracts;
using System.Threading.Tasks;

namespace Mkopa.Core.Services.Interfaces
{
    public interface IProcessSMS
    {
        Task<APIResponseModel<string>> Process(SendSMSContract model);
    }
}
