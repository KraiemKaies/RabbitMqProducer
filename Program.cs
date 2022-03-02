using System.Text;
using Newtonsoft.Json;
using RabbitMQ.Client;
namespace RabbitMQ.Producer
{
    static class Program
    {
        static void Main(string[] args)
        {
            var factory = new ConnectionFactory
            {
                Uri = new Uri("amqp://kraiem:kraiem@localhost:5672")
            };
            using var connection = factory.CreateConnection();
            using var channel = connection.CreateModel();
            channel.QueueDeclare("Demo-queue",
                durable: true,
                exclusive: false,
                autoDelete: false,
                arguments:null);
            var message = new { Name = "Producer", Message = "Hello !"};
            var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(message));
            channel.BasicPublish("","demo-queue",null,body);
        }
    }
}