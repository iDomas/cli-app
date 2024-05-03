using partycli.Models.Entities;
using partycli.Models.Enums;

namespace partycli.Services.Api;

public interface INordVpnApiService
{
    Task<IEnumerable<ServerModel>> GetAllServersListAsync();
    Task<IEnumerable<ServerModel>> GetAllServerByCountryListAsync(CountryCode countryCode);
    Task<IEnumerable<ServerModel>> GetAllServerByProtocolListAsync(int vpnProtocol);
}