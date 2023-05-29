using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using TPL.RabbitMQ.Sub.AppService.Interface;
using TPL.RabbitMQ.Sub.Domain.Models.Mensageria;
using TPL.RabbitMQ.Sub.IoC.Configurations;

namespace TPL.RabbitMQ.Sub.AppService.Service.RabbitMqService
{
    public class SubscriberService
    {
        private RabbitMQConfigutation _rMqConfig;
        private readonly IPropostaService _propostaService;
        public SubscriberService(IOptions<RabbitMQConfigutation> rabbitMQConfigutation, IPropostaService propostaService)
        {
            _rMqConfig = rabbitMQConfigutation.Value;
            _propostaService = propostaService;
        }

        public void Consume()
        {
            var connectionFactory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = connectionFactory.CreateConnection())
            {
                using (var model = connection.CreateModel())
                {
                    #region Declarações caso seja necessário criar as filas
                    model.ExchangeDeclare(exchange: _rMqConfig.Exchange, type: _rMqConfig.ExchangeType, durable: true, autoDelete: false);
                    model.QueueDeclare(queue: _rMqConfig.Queue, durable: true, autoDelete: false);
                    model.QueueBind(queue: _rMqConfig.Queue, exchange: _rMqConfig.Exchange, routingKey: _rMqConfig.RoutingKey);
                    model.BasicQos(prefetchSize: 0, prefetchCount: 100, global: false);
                    #endregion

                    var consumer = new EventingBasicConsumer(model);

                    consumer.Received += (innerModel, eventArgs) =>
                    {
                        var mensagem = new Mensagem();

                        #region Decoding
                        try
                        {

                            var contentArray = eventArgs.Body.ToArray();
                            var message = Encoding.UTF8.GetString(contentArray);
                            mensagem = JsonConvert.DeserializeObject<Mensagem>(message);

                            if (mensagem == null)
                                throw new Exception("Mensagem nula");

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Erro ao converter a mensagem.");
                            model.BasicNack(eventArgs.DeliveryTag, false, false);
                            throw;
                        }
                        #endregion

                        try
                        {
                            var result = _propostaService.VerificarProposta(mensagem.Body.TicketId);

                            if (result)
                                model.BasicAck(deliveryTag: eventArgs.DeliveryTag, multiple: false);
                            else
                                model.BasicNack(eventArgs.DeliveryTag, false, false);

                        }
                        catch (Exception)
                        {
                            Console.WriteLine($"Erro ao processar a mensagem.");
                            model.BasicNack(eventArgs.DeliveryTag, false, false);
                            throw;
                        }
                    };

                    model.BasicConsume(queue: _rMqConfig.Queue, autoAck: false, consumer: consumer);
                }
            }
        }
    }
}
