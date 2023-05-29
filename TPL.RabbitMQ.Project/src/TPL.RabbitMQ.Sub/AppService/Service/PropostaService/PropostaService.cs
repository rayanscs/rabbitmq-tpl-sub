using TPL.RabbitMQ.Sub.AppService.Interface;

namespace TPL.RabbitMQ.Sub.AppService.Service.PropostaService
{
    public class PropostaService : IPropostaService
    {
        public PropostaService()
        {
            
        }

        public bool VerificarProposta(string ticketId)
        {
            Console.WriteLine($"O ticket da proposta é: {ticketId}");
            return true;
        }
    }
}
