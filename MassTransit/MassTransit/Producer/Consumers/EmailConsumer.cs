using MassTransit;
using System;
using System.Threading.Tasks;

namespace Producer.Consumers
{
    public class EmailConsumer : IConsumer<IMessage>
    {
        public async Task Consume(ConsumeContext<IMessage> context)
        {
            await Console.Out.WriteLineAsync($"Email message content: {context.Message.Content}");
        }
    }
}
