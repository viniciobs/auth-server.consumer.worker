using AuthServer.Consumer.Worker.Settings;
using Confluent.Kafka;

namespace AuthServer.Consumer.Worker.Factories
{
    internal class ConsumerFactory
    {
        public static IConsumer<Ignore, string> CreateConsumer(BrokerSettings brokerSettings)
        {
            var consumer = new ConsumerBuilder<Ignore, string>(
                new ConsumerConfig
                {
                    BootstrapServers = brokerSettings.BootstrapServers,
                    GroupId = brokerSettings.GroupId,
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    EnableAutoCommit = true,
                }).Build();

            consumer.Subscribe(brokerSettings.Topic);

            return consumer;
        }
    }
}
