using System.ComponentModel;
using Spectre.Console;
using Spectre.Console.Cli;

namespace partycli.cli;

public sealed class ServerListCommand : AsyncCommand<ServerListCommand.ServerListCommandSettings>
{
    public sealed class ServerListCommandSettings : CommandSettings
    {
        [CommandOption("-t|--TCP")]
        [Description("TCP option")]
        public bool? TcpOption { get; set; }
        
        [CommandOption("-l|--local")]
        [Description("Local option")]
        public bool? LocalOption { get; set; }
        
        [CommandOption("-c|--country <country>")]
        [Description("Country option")]
        public string? CountryOption { get; set; }
    }

    public override Task<int> ExecuteAsync(CommandContext context, ServerListCommandSettings settings)
    {
        if (settings.TcpOption == true)
        {
            return Task.FromResult(1);
        }
        AnsiConsole.MarkupLine($"setting: {settings?.TcpOption}");
        AnsiConsole.MarkupLine($"setting: {settings?.LocalOption}");
        AnsiConsole.MarkupLine($"setting: {settings?.CountryOption}");
        return Task.FromResult(0);
    }
}
