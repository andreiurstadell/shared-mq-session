using RabbitMQ.Client;
using System;
using System.Text;

namespace Publisher
{
    //    Implement simple console app with Producer and Consumer using RabbitMq.Client:
    //      •	One Producer: can product type doc and email
    //      •	Two Consumers: doc consumer and email consumer
    //      •	Email consumer will also publish to audit queue
    //      •	Implement audit consumer
    //      •	Transform to HostedService in asp net core web app


    class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare("firstExchange", "fanout", true, false);
                channel.QueueDeclare(queue: "firstDeclare",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);
                channel.QueueBind("firstDeclare", "firstExchange", string.Empty);

                channel.BasicPublish(exchange: "firstExchange",
                                     routingKey: string.Empty,
                                     basicProperties: null,
                                     body: body);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}

