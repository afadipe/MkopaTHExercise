using Mkopa.Core.DTO;
using Mkopa.Core.ServiceBusContracts;
using Mkopa.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mkopa.Core.Services.Implementations
{
    public class NGNProvider : ISMSProvider
    {
        public async Task<SMSProviderResponse> SendSMS(SendSMSContract payload)
        {
            return await Task.FromResult(new SMSProviderResponse
            {
                ProviderMessdageId= Guid.NewGuid().ToString(),
                Code= System.Net.HttpStatusCode.OK,
                Provider = "NGN"
            });

        }
    }
}
