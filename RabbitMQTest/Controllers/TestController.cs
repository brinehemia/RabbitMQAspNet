using MassTransit;
using Microsoft.AspNetCore.Mvc;
using RabbitMQTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RabbitMQTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public TestController(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        // GET: api/<TestController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] TestMessage value)
        {
            //Send to rabbitmq server
            _publishEndpoint.Publish<TestMessage>(value);

            return Ok();
        }
    }
}
