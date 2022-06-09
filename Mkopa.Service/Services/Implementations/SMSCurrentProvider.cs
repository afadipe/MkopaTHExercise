using Microsoft.Extensions.Logging;
using Mkopa.Core.Services.Interfaces;
using System;

namespace Mkopa.Core.Services.Implementations
{
    public class SMSCurrentProvider : ISMSCurrentProvider
    {
        private readonly ILoggerFactory _loggerFactory;

        public SMSCurrentProvider( ILoggerFactory loggerFactory)
        {
            _loggerFactory = loggerFactory;
        }

        public ISMSProvider GetCurrentSMSProvider(string phoneNumber)
        {
            return new NGNProvider();
        }
    }
}
