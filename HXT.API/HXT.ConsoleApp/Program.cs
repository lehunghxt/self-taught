using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace RabbitMQProduct.ConsoleApplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Specify the connection factory for RabbitMQ
            var factory = new ConnectionFactory
            {
                HostName = "localhost"
            };
            // Create a connection to RabbitMQ
            var connection = factory.CreateConnection();
            // Create a channel
            using var channel = connection.CreateModel();
            // Declare a queue
            channel.QueueDeclare(queue: "ProductQueue", durable: false, exclusive: false, autoDelete: false);
            // Create a consumer
            var consumer = new EventingBasicConsumer(channel);
            // Register the consumer
            consumer.Received += (model, eventArgs) => {
                // Consume the message
                var body = eventArgs.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                Console.WriteLine($"Product message received: {message}");
            };
            // Consume the message
            channel.BasicConsume(queue: "ProductQueue", autoAck: true, consumer: consumer);
            // Wait for the user to press a key
            Console.ReadKey();
        }
    }
}