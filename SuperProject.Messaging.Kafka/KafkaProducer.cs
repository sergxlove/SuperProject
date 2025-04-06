using Confluent.Kafka;
using Microsoft.Extensions.Options;
using SuperProject.Messaging.Kafka.Abstractions;
using SuperProject.Messaging.Kafka.Serializers;

namespace SuperProject.Messaging.Kafka
{
    public class KafkaProducer<TMessage> : IKafkaProducer<TMessage>
    {
        private readonly IProducer<string, TMessage> producer;
        private readonly string topic;
        public KafkaProducer(IOptions<KafkaSettings> options)
        {
            var config = new ProducerConfig()
            {
                BootstrapServers = options.Value.BootstrapServers
            };

            producer = new ProducerBuilder<string, TMessage>(config)
                .SetValueSerializer(new KafkaJsonSerializer<TMessage>())
                .Build();

            topic = options.Value.Topic;
        }
        public void Dispose()
        {
            producer?.Dispose();
        }

        public async Task ProduceAsync(TMessage message, CancellationToken token)
        {
            await producer.ProduceAsync(topic, new Message<string, TMessage>
            {
                Key = "uniq1",
                Value = message
            }, token);
        }
    }
}
