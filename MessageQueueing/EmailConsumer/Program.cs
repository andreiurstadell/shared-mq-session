using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;

namespace EmailConsumer
{
    class Program
    {
        private static IModel _channel;
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                _channel = connection.CreateModel();
                _channel.QueueDeclare(queue: "emailQueue",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                _channel.QueueBind("emailQueue", "firstExchange", string.Empty);

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += ConsumerReceived;
                _channel.BasicConsume("emailQueue", false, consumer);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
                _channel.Close();
            }

        }

        private static void ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine(" [x]Email Consumer has received {0}", message);
            _channel.BasicAck(e.DeliveryTag, false);
        }
    }
}
