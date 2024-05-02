using partycli.Services.App;
using Spectre.Console;

namespace partycli.Services.UI;

public class UiService(IServerService serverService) : IUiService
{
    public async Task DisplayLocalServers()
    {
        var servers = serverService
            .GetServersAsync()
            .Result;

        var serverList = servers.ToList();
        
        if (serverList.Count == 0)
        {
            AnsiConsole.MarkupLine("[red]Error: There are no server data in local storage[/]");
            return;
        }
        
        serverList
            .ForEach(server =>
            {
                if (string.Equals(server.Status, "online"))
                    AnsiConsole.MarkupLine($"{server.Name} - [green]{server.Status}[/]");
                else 
                    AnsiConsole.MarkupLine($"{server.Name} - [red]{server.Status}[/]");
            });
        AnsiConsole.MarkupLine($"Total servers: [bold]{serverList.Count}[/]");
    }
}