using partycli.Models.Entities;

namespace partycli.Services.Api;

public interface INordVpnApiService
{
    Task<IEnumerable<ServerModel>> GetAllServersListAsync();
    Task<IEnumerable<ServerModel>> GetAllServerByCountryListAsync(int countryId);
    Task<IEnumerable<ServerModel>> GetAllServerByProtocolListAsync(int vpnProtocol);
}