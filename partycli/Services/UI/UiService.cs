using partycli.Models;
using partycli.Models.Entities;
using partycli.Models.Enums;
using partycli.Services.App;
using Spectre.Console;

namespace partycli.Services.UI;

public class UiService(IServerService serverService, IConfigService configService) : IUiService
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

    public void DisplayConfigSelection()
    {
        var query = new DisplayQuery(DisplayType.AllServers);
        var servers = 
            GetServersAsync(query)
                .Result;

        var selectionPrompt = new SelectionPrompt<ServerModel>()
            .Title("Select server:")
            .PageSize(10)
            .MoreChoicesText("[grey](Move up and down to reveal more servers)[/]")
            .AddChoices(servers);
        selectionPrompt.SearchEnabled = true;

        var server = AnsiConsole.Prompt(selectionPrompt);
        try 
        {
            configService.SaveConfigAsync(server).Wait();
        }
        catch (Exception e)
        {
            AnsiConsole.MarkupLine($"[red]Error: {e.Message}[/]");
        }
    }

    public void DisplayCurrentConfig()
    {
        var config = configService.LoadConfigAsync().Result;
        if (config == null)
        {
            AnsiConsole.MarkupLine("[red]Error: There are no active configuration...[/]");
            return;
        }
        
        var server = serverService.GetServerByIdAsync(config.ServerId).Result;
        if (server == null)
        {
            AnsiConsole.MarkupLine("[red]Error: Config exists, but no such server...[/]");
            return;
        }
        AnsiConsole.MarkupLine($"Current server: [bold]{server.Name}[/]");
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
                return await serverService.GetAllServerByProtocolListAsync(query.VpnProtocol);
            default:
                return Enumerable.Empty<ServerModel>().ToList();
        }
    }
}