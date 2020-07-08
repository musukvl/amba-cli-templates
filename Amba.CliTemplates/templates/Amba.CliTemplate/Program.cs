using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using McMaster.Extensions.CommandLineUtils;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Amba.CliTemplate
{
    [Command(Name = "di", Description = "Dependency Injection sample project")]
    [HelpOption]
    class Program
    {
        //Configure command options here:

        [Argument(0, Description = "your name")]
        public string Name { get; } = "dependency injection";

        [Option("-l|--language", Description = "your desired language")]
        [AllowedValues("english", "spanish", IgnoreCase = true)]
        public string Language { get; } = "english";

        public static async Task<int> Main(string[] args)
        {
            return await new HostBuilder()
                .ConfigureLogging((context, builder) =>
                {
                    builder.AddConsole();
                })
                .ConfigureServices(ConfigureServices)
                .RunCommandLineApplicationAsync<Program>(args);
        }

        private static void ConfigureServices(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<Command>();
            services.AddSingleton<IConsole>(PhysicalConsole.Singleton);
            services.AddAutoMapper(typeof(Program).Assembly);
            // Configure App services Here
        }


        private readonly Command _command;

        public Program(Command command)
        {
            _command = command;
        }

        private Task<int> OnExecuteAsync(CommandLineApplication app, CancellationToken cancellationToken)
        {
            var mapper = app.GetService<IMapper>();
            var commandParameters = mapper.Map<CommandParameters>(this);
            return _command.RunAsync(commandParameters, cancellationToken);
        }
    }




}
