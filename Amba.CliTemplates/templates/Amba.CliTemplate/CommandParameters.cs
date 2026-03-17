using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace Amba.CliTemplate
{
    internal sealed class GreetingCommandSettings : CommandSettings
    {
        [CommandArgument(0, "<name>")]
        [Description("your name")]
        public string Name { get; init; } = string.Empty;

        [CommandOption("-l|--language <LANGUAGE>")]
        [Description("your desired language")]
        [DefaultValue("english")]
        public string Language { get; init; } = "english";

        public override ValidationResult Validate()
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                return ValidationResult.Error("Name is required.");
            }

            var language = Language.Trim().ToLowerInvariant();
            if (language != "english" && language != "spanish")
            {
                return ValidationResult.Error("Language must be either 'english' or 'spanish'.");
            }

            return ValidationResult.Success();
        }
    }
}