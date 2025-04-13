using SuperProject.Messaging.Kafka.Abstractions;
using SuperProject.Messaging.Kafka.Models;

namespace SuperProject.Messaging.Kafka.Handlers
{
    public class MessageHandler : IMessageHandler<Order>
    {
        public Task HandleAsync(Order message, CancellationToken token)
        {
            Console.WriteLine($"{message.Id} - {message.Name}");
            return Task.CompletedTask;
        }
    }
}
