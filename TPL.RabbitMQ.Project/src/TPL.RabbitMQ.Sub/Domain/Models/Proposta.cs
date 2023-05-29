using Newtonsoft.Json;

namespace TPL.RabbitMQ.Sub.Domain.Models
{
    public class Proposta
    {
        [JsonProperty("ticketId")]
        public string TicketId { get; set; }
        public string Nome { get; set; }
    }
}
