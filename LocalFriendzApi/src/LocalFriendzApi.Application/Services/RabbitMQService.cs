using RabbitMQ.Client;
using System.Text;
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

            // Declaração das filas
            DeclareQueue("contactQueue");
            DeclareQueue("fila-sentimento");
        }

        private void DeclareQueue(string queueName)
        {
            _channel.QueueDeclare(queue: queueName,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);
        }

        public void SendMessage(string message)
        {
            var body = Encoding.UTF8.GetBytes(message);
            PublishMessage("contactQueue", body);
            PublishMessage("fila-sentimento", body);
        }

        private void PublishMessage(string queueName, byte[] body)
        {
            _channel.BasicPublish(exchange: "",
                                 routingKey: queueName,
                                 basicProperties: null,
                                 body: body);
        }
    }
}
