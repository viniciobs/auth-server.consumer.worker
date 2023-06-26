using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace AuthServer.Consumer.Worker.Models
{
    internal record Email
    {
        public Guid UserId { get; init; }

        [JsonProperty("Email")]
        public string Address { get; init; } = string.Empty;
        
        public string UserName { get; init; } = string.Empty;
        
        public string ConfirmationToken { get; init; } = string.Empty;
    }
}
