namespace SuperProject.Messaging.Kafka.Handlers
{
    public interface IMessageHandler<in TMessage>
    {
        Task HandleAsync(TMessage message, CancellationToken token);
    }
}
