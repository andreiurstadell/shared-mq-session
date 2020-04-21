using MassTransit.Audit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producer
{
    public class AuditStore : IMessageAuditStore
    {
        public Task StoreMessage<T>(T message, MessageAuditMetadata metadata) where T : class
        {
            Console.WriteLine("audit");
            return Task.CompletedTask;
        }
    }
}
