using TPL.RabbitMQ.Sub.AppService.Interface;
using TPL.RabbitMQ.Sub.Domain.Http;
using TPL.RabbitMQ.Sub.IoC.Configurations;

namespace TPL.RabbitMQ.Sub.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddScoped<IPropostaService, IPropostaService>();
            #endregion

            #region Binds
            services.Configure<RestUrls>(opt => configuration.GetSection("RestUrls").Bind(opt));
            services.Configure<RabbitMQConfigutation>(opt => configuration.GetSection("RabbitMQConfiguration").Bind(opt));
            #endregion

            return services;
        }

        public static IServiceCollection RegisterLog(this IServiceCollection services, IConfiguration configuration)
        {
            return services;
        }
    }
   
}
