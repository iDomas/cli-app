using partycli.Database.Repository;
using partycli.Models;
using partycli.Models.Constant;
using partycli.Models.Entities;
using partycli.Models.Enums;
using partycli.Services.Api;
using Spectre.Console;

namespace partycli.Services.App;

public class ServerService(
    IServerRepository serverRepository,
    INordVpnApiService nordVpnApiService,
    ILogService logService) : IServerService
{
    private const string SavedToContextStr = "[green]Saved to context...[/]";
    private const string FailedToFetchApi = "[red]Failed to get servers from API[/]";
    
    public async Task<IEnumerable<ServerModel>> GetServersAsync()
    { 
        if (await SaveServersFromApi())
            AnsiConsole.MarkupLine(SavedToContextStr);
        return await Task.Run(() => serverRepository.GetServers().AsEnumerable());
    }

    public async Task<IEnumerable<ServerModel>> GetLocalServersAsync()
    {
        return await Task.Run(() => serverRepository.GetServers().AsEnumerable());
    }

    public async Task<IEnumerable<ServerModel>> GetAllServerByCountryListAsync(CountryCode countryCode)
    {
        return await SaveServersByCountry(countryCode);
    }

    public async Task<IEnumerable<ServerModel>> GetAllServerByProtocolListAsync(Protocol vpnProtocol)
    {
        return await SaveServersByVpnProtocol(vpnProtocol);
    }

    private async Task<bool> SaveServersFromApi()
    {
        try
        {
            var servers = await nordVpnApiService.GetAllServersListAsync();
            await SaveServerState(servers);
            return true;
        }
        catch
        {
            AnsiConsole.MarkupLine(FailedToFetchApi);
            return false;
        }
    }

    private async Task<IEnumerable<ServerModel>> SaveServersByCountry(CountryCode countryCode)
    {
        try
        {
            var servers = await nordVpnApiService.GetAllServerByCountryListAsync(countryCode);
            await SaveServerState(servers);
            return servers;
        }
        catch
        {
            AnsiConsole.MarkupLine(FailedToFetchApi);
            return Enumerable.Empty<ServerModel>();
        }
    }

    private async Task<IEnumerable<ServerModel>> SaveServersByVpnProtocol(Protocol vpnProtocol)
    {
        try
        {
            var servers = await nordVpnApiService.GetAllServerByProtocolListAsync(vpnProtocol);
            await SaveServerState(servers);
            return servers;
        }
        catch
        {
            AnsiConsole.MarkupLine(FailedToFetchApi);
            return Enumerable.Empty<ServerModel>();
        }
    }

    private async Task SaveServerState(IEnumerable<ServerModel> servers)
    {
        await serverRepository.AddOrUpdateServers(servers);
        await logService.Log(new LogMessage()
        {
            Action = ActionType.ServerSaved,
            MessageParam = servers.Count().ToString()
        });
    }
}