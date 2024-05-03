using System.Net;
using System.Text.Json;
using partycli.Models.Entities;
using partycli.Models.Enums;
using Spectre.Console;
using HttpClient = System.Net.Http.HttpClient;

namespace partycli.Services.Api;

public sealed class NordVpnApiService : INordVpnApiService
{
    private const string BaseUrl = "https://api.nordvpn.com/v1/servers";
    
    public async Task<IEnumerable<ServerModel>> GetAllServersListAsync()
    {
        try
        {
            return await GetServersAsync(BaseUrl);
        }
        catch
        {
            AnsiConsole.MarkupLine("[red]Failed to get servers list[/]");
            return Enumerable.Empty<ServerModel>();
        }
    }

    public async Task<IEnumerable<ServerModel>> GetAllServerByCountryListAsync(CountryCode countryCode)
    {
        try
        {
            var countryId = (int)countryCode;
            var requestUrl = $"{BaseUrl}?filters[servers_technologies][id]=35&filters[country_id]={countryId}";
            return await GetServersAsync(requestUrl);
        } catch
        {
            AnsiConsole.MarkupLine("[red]Failed to get servers list by country[/]");
            return Enumerable.Empty<ServerModel>();
        }
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

    private async Task<IEnumerable<ServerModel>> GetServersAsync(string requestUrl)
    {
        var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(requestUrl);
        if (response.StatusCode != HttpStatusCode.OK)
        {
            AnsiConsole.MarkupLine($"[red]Failed to get servers list by country: {response.StatusCode}[/]");
            return Enumerable.Empty<ServerModel>();
        }
            
        var body = await response.Content.ReadAsStringAsync();
        return ParseResponse(body);
    }
}