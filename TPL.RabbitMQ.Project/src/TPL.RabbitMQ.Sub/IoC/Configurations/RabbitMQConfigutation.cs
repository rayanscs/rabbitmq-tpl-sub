namespace TPL.RabbitMQ.Sub.IoC.Configurations
{
    public class RabbitMQConfigutation
    {
        public string Host { get; set; } = string.Empty;
        public ushort Port { get; set; }
        public string User { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string VirtualHost { get; set; } = string.Empty;
        public string Exchange { get; set; } = string.Empty;
        public string ExchangeType { get; set; } = string.Empty;
        public string Queue { get; set; } = string.Empty;
        public string RoutingKey { get; set; } = string.Empty;
        public string QueuePublisher { get; set; } = string.Empty;
        public string RoutingKeyPublisher { get; set; } = string.Empty;
    }
}
