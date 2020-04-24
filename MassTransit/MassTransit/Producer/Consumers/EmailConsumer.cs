using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Producer.Consumers
{
    public class EmailConsumer : IConsumer<IEmailMessage>
    {
        private readonly ILogger<EmailConsumer> _logger;

        public EmailConsumer(ILogger<EmailConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<IEmailMessage> context)
        {
            _logger.LogInformation($"Email message content: {context.Message.Content}");
            return Task.CompletedTask;
        }
    }
}
