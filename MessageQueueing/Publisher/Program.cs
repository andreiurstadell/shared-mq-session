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
                channel.ExchangeDeclare("firstExchange", "direct", true, false);
                channel.QueueDeclare(queue: "firstDeclare",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello World!";
                string message2 = "hello world2";
                var body = Encoding.UTF8.GetBytes(message);
                var body2 = Encoding.UTF8.GetBytes(message2);
                channel.QueueBind("firstDeclare", "firstExchange", "doc");

                channel.BasicPublish(exchange: "firstExchange",
                                     routingKey: "doc",
                                     basicProperties: null,
                                     body: body);
                channel.BasicPublish(exchange: "firstExchange",
                                     routingKey: "doc",
                                     basicProperties: null,
                                     body: body2);
                Console.WriteLine(" [x] Sent {0}", message);
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
    }
}

