using MassTransit;
using RabbitMQTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RabbitMQTest.Services
{
    public interface ITestService
    {
        
    }
   
    public class TetsService : ITestService, IConsumer<TestMessage>
    {
        public async Task Consume(ConsumeContext<TestMessage> test)
        {
            // get message ( Name )
            var GetMessage = test.Message.Name;
        }
    }
}
