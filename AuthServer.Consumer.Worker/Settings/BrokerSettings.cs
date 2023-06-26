namespace AuthServer.Consumer.Worker.Settings
{
    public record BrokerSettings(
        string BootstrapServers,
        string GroupId,
        string Topic);   
}