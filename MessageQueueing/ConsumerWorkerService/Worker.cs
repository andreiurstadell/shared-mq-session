using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace ConsumerWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private IConnection _connection;
        private IModel _channel;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           var factory = new ConnectionFactory() { HostName = "localhost" };
           _connection = factory.CreateConnection();
            
                _channel = _connection.CreateModel();

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += ConsumerReceived;
                _channel.BasicConsume("firstDeclare", false, consumer);
                _logger.LogInformation(" Press [enter] to exit.");
                
        }

        private  void ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine(" [x]Doc Consumer has received {0}", message);
            _channel.BasicAck(e.DeliveryTag, false);
        }

        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }
    }
}
