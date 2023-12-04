using Microsoft.AspNetCore.Mvc;
using WepAPIProducerPOC.ServiceBus;

namespace WepAPIProducerPOC.Controllers
{
    [ApiController]
    [Route("api/sendmessage")]
    public class ProducerController : Controller
    {

        private readonly IServiceBusSender _serviceBus;

        public ProducerController(IServiceBusSender serviceBus) {
            this._serviceBus = serviceBus; 
        }

        [HttpPost(Name = "sendmessage")]
        public async Task<IActionResult> Create([FromBody] dynamic message)
        {
            Console.WriteLine(message);

            await this._serviceBus.SendMessageAsync(message);

            return Ok();
        }
    }
}
