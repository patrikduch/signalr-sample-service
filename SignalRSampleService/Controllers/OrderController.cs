using MassTransit;
using Microsoft.AspNetCore.Mvc;
using SignalRSampleService.RabbitMq.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SignalRSampleService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IPublishEndpoint _publishEndpoint;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="publishEndpoint">Helps us to publish messages into RabbitMQ message broker.</param>
        public OrderController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }



        // POST: api/<CompanyController>
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Order order)
        {
            await _publishEndpoint.Publish<Order>(order);

            return Ok();
        }
    }
}
