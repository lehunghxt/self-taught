using RabbitMQ.Client;

namespace HXT.RabitMQ
{
    public class RabbitMQProducer : IRabbitMQProducer
    {
        public void SendProductMessage<T>(T message)
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            channel.QueueDeclare(queue: "ProductQueue", durable: false, exclusive: false, autoDelete: false, arguments: null);
            var json = System.Text.Json.JsonSerializer.Serialize(message);
            var body = System.Text.Encoding.UTF8.GetBytes(json);
            channel.BasicPublish(exchange: "", routingKey: "ProductQueue", basicProperties: null, body: body);
        }
    }
}
