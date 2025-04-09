using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SuperProject.Messaging.Kafka.Handlers;
using SuperProject.Messaging.Kafka.Serializers;

namespace SuperProject.Messaging.Kafka
{
    public class KafkaConsumer<TMessage> : BackgroundService
    {
        private readonly string _topic;

        private readonly IConsumer<string, TMessage> _consumer;

        private readonly IMessageHandler<TMessage> _messageHandler;

        public KafkaConsumer(IOptions<KafkaSettings> options, IMessageHandler<TMessage> messageHandler)
        {
            var config = new ConsumerConfig()
            {
                BootstrapServers = options.Value.BootstrapServers,
                GroupId = options.Value.GroupId,
                AutoOffsetReset = AutoOffsetReset.Earliest
            };

            _topic = options.Value.Topic;

            _consumer = new ConsumerBuilder<string, TMessage>(config)
                .SetValueDeserializer(new KafkaJsonDeserializer<TMessage>())
                .Build();

            _messageHandler = messageHandler;
        }
        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            throw new NotImplementedException();
        }
    }
}
