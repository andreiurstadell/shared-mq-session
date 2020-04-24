using MassTransit;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;

namespace Producer.Consumers
{
    public class AuditConsumer : IConsumer<IEmailMessage>, IConsumer<IDocMessage> 
    {
        private readonly ILogger<AuditConsumer> _logger;

        public AuditConsumer(ILogger<AuditConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<IEmailMessage> context)
        {
            _logger.LogInformation($"Audit Email message content: {context.Message.Content}");
            return Task.CompletedTask;
        }

        public Task Consume(ConsumeContext<IDocMessage> context)
        {
            _logger.LogInformation($"Audit Doc message content: {context.Message.Text}");
            return Task.CompletedTask;
        }
    }
}
