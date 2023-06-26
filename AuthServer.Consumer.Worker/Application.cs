using AuthServer.Consumer.Worker.Settings;
using Microsoft.Extensions.Configuration;

namespace AuthServer.Consumer.Worker
{
    internal class Application
    {
        private readonly IConfiguration _config;

        public Application()
        {
            _config = new ConfigurationBuilder()
                        .AddJsonFile($"appsettings.json")
                        .Build();
        }

        public BrokerSettings GetBroker()
        {
            var broker = _config
                .GetSection(nameof(BrokerSettings))
                .Get<BrokerSettings>();

            ArgumentNullException.ThrowIfNull(broker?.BootstrapServers);
            ArgumentNullException.ThrowIfNull(broker?.GroupId);
            ArgumentNullException.ThrowIfNull(broker?.Topic);

            return broker;            
        }

        public ExternalServices GetExternalServices()
        {
            var services = _config
                .GetSection(nameof(ExternalServices))
                .Get<ExternalServices>();

            ArgumentNullException.ThrowIfNull(services?.MailSender);
            ArgumentNullException.ThrowIfNull(services?.MailConfirmation);

            return services;
        }
    }
}