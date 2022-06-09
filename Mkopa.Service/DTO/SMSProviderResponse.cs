using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Mkopa.Core.DTO
{
    public class SMSProviderResponse
    {
        public HttpStatusCode Code { get; set; }
        public string ProviderMessdageId { get; set; }
        public string Provider { get; set; }
    }
}
