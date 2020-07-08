using System;
using System.Threading;
using System.Threading.Tasks;
using McMaster.Extensions.CommandLineUtils;

namespace Amba.CliTemplate
{
    class Command  
    {
        private readonly IConsole _console;

        public Command(IConsole console)
        {
            _console = console;
        }

        public Task<int> RunAsync(CommandParameters commandParameters, CancellationToken cancellationToken = default)
        {
            // Replace with your code
            string greeting;
            switch (commandParameters.Language)
            {
                case "english": greeting = "Hello {0}"; break;
                case "spanish": greeting = "Hola {0}"; break;
                default: throw new InvalidOperationException("validation should have caught this");
            }
            _console.WriteLine(greeting, commandParameters.Name);
            return Task.FromResult(0);
        }
    }
}