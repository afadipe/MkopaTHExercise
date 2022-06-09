using System;

namespace Mkopa.Core.ServiceBusContracts
{
    public class SendSMSContract 
    {
        public Guid MessageKey { get; set; }
        public string PhoneNumber { get; set; }
        public string SmsText { get; set; }
    }
}
