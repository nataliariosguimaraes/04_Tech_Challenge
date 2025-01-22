using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace LocalFriendzApi.Application.IServices
{
    public interface IRabbitMQService
    {
        void SendMessage(string message);
    }
}