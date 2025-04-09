using Confluent.Kafka;
using System.Text.Json;

namespace SuperProject.Messaging.Kafka.Serializers
{
    public class KafkaJsonDeserializer<TMessage> : IDeserializer<TMessage>
    {
        public TMessage Deserialize(ReadOnlySpan<byte> data, bool isNull, SerializationContext context)
        {
            return JsonSerializer.Deserialize<TMessage>(data)!;
        }
    }
}
