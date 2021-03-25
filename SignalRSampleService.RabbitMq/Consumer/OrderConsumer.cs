using MassTransit;
using SignalRSampleService.RabbitMq.Model;
using System;
using System.Threading.Tasks;

namespace SignalRSampleService.RabbitMq.Consumer
{
    public class OrderConsumer : IConsumer<Order>
    {
        public async Task Consume(ConsumeContext<Order> context)
        {
            await Console.Out.WriteLineAsync(context.Message.Name);
        }
    }
}
