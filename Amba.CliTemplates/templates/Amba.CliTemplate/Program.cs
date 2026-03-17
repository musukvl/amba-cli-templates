using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Amba.CliTemplate
{
    internal static class Program
    {
        public static Task<int> Main(string[] args)
        {
            var services = new ServiceCollection();
            ConfigureServices(services);

            var registrar = new TypeRegistrar(services);
            var app = new CommandApp<Command>(registrar);

            app.Configure(config =>
            {
                config.SetApplicationName("hw");
                config.AddExample(new[] { "Vasya", "--language", "spanish" });
            });

            return app.RunAsync(args);
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IAnsiConsole>(AnsiConsole.Console);
            // Configure App services here:
        }
    }
}
