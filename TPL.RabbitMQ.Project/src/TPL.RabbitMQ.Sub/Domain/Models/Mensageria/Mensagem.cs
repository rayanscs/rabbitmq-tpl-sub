using Newtonsoft.Json;

namespace TPL.RabbitMQ.Sub.Domain.Models.Mensageria
{
    public class Mensagem
    {
        [JsonProperty("header")]
        public Header Header { get; set; }

        [JsonProperty("body")]
        public Body Body { get; set; }
    }

    public class Header
    {
        [JsonProperty("projetoOrigem")]
        public string ProjetoOrigem { get; set; }

        [JsonProperty("filaOrigem")]
        public string FilaOrigem { get; set; }

        [JsonProperty("dataEntradaFila")]
        public DateTime DataEntradaFila { get; set; }

        [JsonProperty("qtReprocessamento")]
        public int QtReprocessamento { get; set; }
    }

    public class Body
    {
        [JsonProperty("ticketId")]
        public required string TicketId { get; set; }
    }
}
