using partycli.Database.Repository;
using partycli.Models.Constant;
using partycli.Models.Entities;
using partycli.Services.Api;
using Spectre.Console;

namespace partycli.Services.App;

public class ServerService(
    IServerRepository serverRepository,
    INordVpnApiService nordVpnApiService,
    ILogService logService) : IServerService
{
    public async Task<IEnumerable<ServerModel>> GetServersAsync()
    { 
        if (await SaveServersFromApi())
            AnsiConsole.MarkupLine("[green]Saved to context...[/]");
        return await Task.Run(() => serverRepository.GetServers().AsEnumerable());
    }

    private async Task<bool> SaveServersFromApi()
    {
        try
        {
            var serversApi = await nordVpnApiService.GetAllServersListAsync();
            await serverRepository.AddServers(serversApi);
            await logService.Log(ActionType.ServerSaved);
            return true;
        }
        catch
        {
            AnsiConsole.MarkupLine("[red]Failed to get servers from API[/]");
            return false;
        }
    }
}