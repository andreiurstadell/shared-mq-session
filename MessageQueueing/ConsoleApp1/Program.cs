using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace AuditConsumer
{
    class Program
    {

        private static IModel _channel;
        //private static connection = 
        static void Main(string[] args)
        { 
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                _channel = connection.CreateModel();
                _channel.QueueDeclare(queue: "audit",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);
                
                _channel.QueueBind("audit", "firstExchange", "#");

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += ConsumerReceived;
                _channel.BasicConsume("audit", false, consumer);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
                _channel.Close();
            }

        }

        private static void ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine(message + " has been saved to the DB");
            _channel.BasicAck(e.DeliveryTag, false);
        }
    }
}
