using System.Globalization;

namespace TPL.RabbitMQ.Sub.IoC.Configurations
{
    public static class AppSettingsConfiguration
    {
        public static IConfigurationRoot GetConfiguration()
        {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("pt-BR");
            var ambiente = Environment.GetEnvironmentVariable("DOTNET_ENVIRONMENT")?.Trim();

            if (string.IsNullOrWhiteSpace(ambiente))
            {
                Console.WriteLine("A variavel de ambiente DOTNET_ENVIRONMENT não definida.");
                Environment.Exit(1);
            }

            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, "appsettings.json"), false)
                .AddJsonFile(Path.Combine(AppContext.BaseDirectory, $"appsettings.{ambiente}.json"), false, true)
                .AddInMemoryCollection(new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("Environment", ambiente)
                }).Build();
        }

        
    }
}
