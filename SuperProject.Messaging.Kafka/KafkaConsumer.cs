using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using SuperProject.Messaging.Kafka.Abstractions;
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
            return Task.Run(() => ConsumeAsync(stoppingToken), stoppingToken);
        }

        public override Task StopAsync(CancellationToken cancellationToken)
        {
            _consumer.Close();
            return base.StopAsync(cancellationToken);
        }
        

        private async Task? ConsumeAsync(CancellationToken stoppingToken)
        {
            _consumer.Subscribe(_topic);
            try
            {
                while (!stoppingToken.IsCancellationRequested)
                {
                    var result = _consumer.Consume(stoppingToken);
                    await _messageHandler.HandleAsync(result.Message.Value, stoppingToken);
                }
            }
            catch
            {

            }
        }
 
    }
}
