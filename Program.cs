using RabbitMQ.Client;
using RabbitMqProducer;

namespace RabbitMQ.Producer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://kraiem:123456@127.0.0.1:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            DirectExchangePublisher.Publish(channel);

        }
    }
}