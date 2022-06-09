
using System.Net;

namespace Mkopa.Core.ServiceBusContracts
{
    public class ProcessedSMSContract 
    {
        public HttpStatusCode Code { get; set; }
        public string ProviderMessdageId { get; set; }
        public string Provider { get; set; }
        public string PhoneNumber { get; set; }
        public string SmsText { get; set; }
    }
}
