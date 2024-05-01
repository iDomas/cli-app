using System.Net;
using System.Text.Json;
using partycli.Models.Entities;
using Spectre.Console;

namespace partycli.Services.Api;

public sealed class NordVpnApiService(HttpClient client) : INordVpnApiService
{
    private const string BaseUrl = "https://api.nordvpn.com/server";
    
    public async Task<IEnumerable<ServerModel>> GetAllServersListAsync()
    {
        var response = await client.GetAsync(BaseUrl);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            AnsiConsole.MarkupLine($"[red]Failed to get servers list: {response.StatusCode}[/]");
            return Enumerable.Empty<ServerModel>();
        }
        var body = await response.Content.ReadAsStringAsync();
        return ParseResponse(body);
    }

    public async Task<IEnumerable<ServerModel>> GetAllServerByCountryListAsync(int countryId)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<ServerModel>> GetAllServerByProtocolListAsync(int vpnProtocol)
    {
        throw new NotImplementedException();
    }
    
    private IEnumerable<ServerModel> ParseResponse(string response)
    {
        IEnumerable<ServerModel> servers;
        try
        {
            servers = JsonSerializer.Deserialize<IEnumerable<ServerModel>>(response) 
                      ?? Enumerable.Empty<ServerModel>();
        }
        catch (Exception e)
        {
            AnsiConsole.MarkupLine($"[red]Failed to parse response: {e.Message}[/]");
            return Enumerable.Empty<ServerModel>();
        }
        return servers;
    }
}