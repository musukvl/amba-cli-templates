using System;
using System.Threading;
using System.Threading.Tasks;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Amba.CliTemplate
{
    internal sealed class Command : AsyncCommand<GreetingCommandSettings>
    {
        private readonly IAnsiConsole _console;

        public Command(IConsole console)
        {
            _console = console;
        }

        public override Task<int> ExecuteAsync(CommandContext context, GreetingCommandSettings settings, CancellationToken cancellationToken)
        {
            // Replace with your code
            string greeting;
            switch (settings.Language.Trim().ToLowerInvariant())
            {
                case "english": greeting = "Hello {0}"; break;
                case "spanish": greeting = "Hola {0}"; break;
                default: throw new InvalidOperationException("validation should have caught this");
            }

            _console.WriteLine(string.Format(greeting, settings.Name));
            return Task.FromResult(0);
        }
    }
}