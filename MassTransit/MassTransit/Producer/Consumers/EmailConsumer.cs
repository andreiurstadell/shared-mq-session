using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Producer.Consumers
{
    public class EmailConsumer : IConsumer<IMessage>
    {
        private readonly ILogger<EmailConsumer> _logger;

        public EmailConsumer(ILogger<EmailConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<IMessage> context)
        {
            _logger.LogInformation($"Email message content: {context.Message.Content}");
            return Task.CompletedTask;
        }
    }
}
