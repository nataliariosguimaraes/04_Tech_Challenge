using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using LocalFriendzApi.Application.IServices;

namespace LocalFriendzApi.Application.Services
{
    public class RabbitMQService : IRabbitMQService
    {
        private readonly IConnection _connection;
        private readonly IModel _channel;

        public RabbitMQService()
        {
            var factory = new ConnectionFactory() 
            { 
                HostName = Environment.GetEnvironmentVariable("RABBITMQ_HOST") ?? "localhost" 
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.QueueDeclare(queue: "contactQueue",
                                 durable: false,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            _channel.BasicPublish(exchange: "",
                                 routingKey: "contactQueue",
                                 basicProperties: null,
                                 body: body);
        }
    }
}