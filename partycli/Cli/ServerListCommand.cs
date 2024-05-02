using System.ComponentModel;
using partycli.Database.init;
using partycli.Services.App;
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

    private readonly IServerService _serverService;
    
    public ServerListCommand(IServerService serverService,
        IInitDatabaseService initDbService)
    {
        _serverService = serverService;
        initDbService.Init();
    }
    
    public override async Task<int> ExecuteAsync(CommandContext context, ServerListCommandSettings settings)
    {
        if (settings.TcpOption == true)
        {
            AnsiConsole.MarkupLine($"TCP option: {settings.TcpOption}");
            return 0;
        }
        
        if (settings.LocalOption == true)
        {
            AnsiConsole.MarkupLine($"Local option: {settings.LocalOption}");
            return 0;
        }
        
        if (!string.IsNullOrWhiteSpace(settings.CountryOption))
        {
            AnsiConsole.MarkupLine($"Country option: {settings.CountryOption}");
            return 0;
        }
        
        var servers = _serverService.GetServers().Result;
        AnsiConsole.MarkupLine($"Servers count: {servers.Count()}");
        
        return 0;
    }
}
