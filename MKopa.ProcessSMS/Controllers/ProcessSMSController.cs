using MassTransit.Mediator;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mkopa.Core.Applications.Commands;
using Mkopa.Core.DTO;
using Mkopa.Core.ServiceBusContracts;
using Mkopa.Core.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MKopa.ProcessSMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcessSMSController : ControllerBase
    {
        private readonly ILogger<ProcessSMSController> _logger;
        private readonly IProcessSMS _processSMS;
        public ProcessSMSController(ILogger<ProcessSMSController> logger, IProcessSMS processSMS)
        {
            _logger = logger;
            _processSMS = processSMS;
        }

        /// <summary>
        /// create order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(typeof(APIResponseModel<string>), 200)]
        public async Task<IActionResult> Get() 
        {
            try
            {
                var xmodel = new SendSMSContract
                {
                    MessageKey = Guid.NewGuid(),
                    PhoneNumber = "048474444",
                    SmsText = "eeeer"
                };
                await _processSMS.Process(xmodel);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
