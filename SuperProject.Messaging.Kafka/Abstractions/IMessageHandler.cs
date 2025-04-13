namespace SuperProject.Messaging.Kafka.Abstractions
{
    public interface IMessageHandler<in TMessage>
    {
        Task HandleAsync(TMessage message, CancellationToken token);
    }
}
