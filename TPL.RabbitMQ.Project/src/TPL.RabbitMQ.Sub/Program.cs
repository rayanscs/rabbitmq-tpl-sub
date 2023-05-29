using TPL.RabbitMQ.Sub;
using TPL.RabbitMQ.Sub.IoC;
using TPL.RabbitMQ.Sub.IoC.Configurations;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        var configuration = AppSettingsConfiguration.GetConfiguration();
        services.AddSingleton(configuration);
        services.RegisterServices(configuration);
        services.RegisterLog(configuration);
        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
