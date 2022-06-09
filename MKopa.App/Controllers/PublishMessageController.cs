using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mkopa.Core.Applications.Commands;
using Mkopa.Core.DTO;
using System.Threading.Tasks;

namespace MKopa.App.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishMessageController : ControllerBase
    {
        private readonly ILogger<PublishMessageController> _logger;
        private readonly IMediator _mediator;
        public PublishMessageController(ILogger<PublishMessageController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        /// <summary>
        /// create order
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(typeof(APIResponseModel<string>), 200)]
        public async Task<IActionResult> Post([FromBody] SendSMSDto model) => Ok(await _mediator.Send(new SendSMSCommand(model)));
    }
}
