using partycli.Database.Repository;
using partycli.Models.Entities;
using partycli.Services.Api;
using Spectre.Console;

namespace partycli.Services.App;

public class ServerService(
    IServerRepository serverRepository,
    INordVpnApiService nordVpnApiService) : IServerService
{
    public async Task<IEnumerable<ServerModel>> GetServers()
    {
        try
        {
            await SaveServersFromApi();
        }
        catch
        {
            AnsiConsole.MarkupLine("[red]Failed to get servers from API[/]");
        }
        return serverRepository.GetServers().AsEnumerable();
    }

    public Task<bool> SaveServers(IEnumerable<ServerModel> servers)
    {
        throw new NotImplementedException();
    }
    
    private async Task SaveServersFromApi()
    {
        var serversApi = await nordVpnApiService.GetAllServersListAsync();
        await serverRepository.AddServers(serversApi);
    }
}