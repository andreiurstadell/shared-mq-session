using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Producer.Consumers
{
    public class DocConsumer : IConsumer<IDocMessage>
    {
        private readonly ILogger<DocConsumer> _logger;

        public DocConsumer(ILogger<DocConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<IDocMessage> context)
        {
            _logger.LogInformation($"Document message content: {context.Message.Text}");
            return Task.CompletedTask;
        }
    }
}
