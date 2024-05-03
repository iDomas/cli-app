using partycli.Models;
using partycli.Models.Entities;
using partycli.Models.Enums;
using partycli.Services.App;
using Spectre.Console;

namespace partycli.Services.UI;

public class UiService(IServerService serverService) : IUiService
{
    public void DisplayServers(DisplayQuery query)
    {
        var servers = 
            GetServersAsync(query)
            .Result;
        
        if (!servers.Any())
        {
            AnsiConsole.MarkupLine("[red]Error: There are no server data in local storage[/]");
            return;
        }
        
        servers
            .ToList()
            .ForEach(server =>
            {
                AnsiConsole.MarkupLine(string.Equals(server.Status, "online")
                    ? $"{server.Name} - [green]{server.Status}[/]"
                    : $"{server.Name} - [red]{server.Status}[/]");
            });
        AnsiConsole.MarkupLine($"Total servers: [bold]{servers.Count()}[/]");
    }
    
    private async Task<IEnumerable<ServerModel>> GetServersAsync(DisplayQuery query)
    {
        switch (query.displayType)
        {
            case DisplayType.AllServers:
                return await serverService.GetServersAsync();
            case DisplayType.LocalServers:
                return await serverService.GetLocalServersAsync();
            case DisplayType.CountryServers:
                if (query.CountryCode != CountryCode.None)
                    return await serverService.GetAllServerByCountryListAsync(query.CountryCode);
                AnsiConsole.MarkupLine("[red]Error: Country code is not provided[/]");
                return Enumerable.Empty<ServerModel>().ToList();
            case DisplayType.TcpServers:
                break;
            default:
                return Enumerable.Empty<ServerModel>().ToList();
        }

        return Enumerable.Empty<ServerModel>().ToList();
    }
}