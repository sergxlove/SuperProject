namespace SuperProject.Messaging.Kafka
{
    public class KafkaSettings
    {
        public string BootstrapServers { get; set; } = string.Empty;
        public string Topic { get; set; } = string.Empty;
        public string GroupId { get; set; } = string.Empty;
    }
}
