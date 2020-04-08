using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace Consumer
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

                var consumer = new EventingBasicConsumer(_channel);
                consumer.Received += ConsumerReceived;
                _channel.BasicConsume("firstDeclare", false, consumer);
                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
                _channel.Close();
            }

        }

        private static void ConsumerReceived(object sender, BasicDeliverEventArgs e)
        {
            var message = Encoding.UTF8.GetString(e.Body);
            Console.WriteLine(" [x]Received {0}", message);
            _channel.BasicAck(e.DeliveryTag, false);
        }
    }
}
