using MassTransit;
using Microsoft.Extensions.Logging;
using Producer.Messages;
using System;
using System.Threading.Tasks;

namespace Producer.Consumers
{
    public class AuditConsumer : IConsumer<IAuditMessage>
    {
        private readonly ILogger<AuditConsumer> _logger;

        public AuditConsumer(ILogger<AuditConsumer> logger)
        {
            _logger = logger;
        }

        public Task Consume(ConsumeContext<IAuditMessage> context)
        {
            _logger.LogInformation($"Audit message content: {System.Text.Json.JsonSerializer.Serialize(context.Message)}");
            return Task.CompletedTask;
        }
    }
}
