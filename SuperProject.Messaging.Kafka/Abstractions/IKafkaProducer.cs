namespace SuperProject.Messaging.Kafka.Abstractions
{
    public interface IKafkaProducer<in TMessage> : IDisposable
    {
        Task ProduceAsync(TMessage message, CancellationToken token);
    }
}
