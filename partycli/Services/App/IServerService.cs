using partycli.Models.Entities;
using partycli.Models.Enums;

namespace partycli.Services.App;

public interface IServerService
{
    Task<ServerModel?> GetServerByIdAsync(int serverId);
    Task<IEnumerable<ServerModel>> GetServersAsync();
    Task<IEnumerable<ServerModel>> GetLocalServersAsync();
    Task<IEnumerable<ServerModel>> GetAllServerByCountryListAsync(CountryCode countryCode);
    Task<IEnumerable<ServerModel>> GetAllServerByProtocolListAsync(Protocol vpnProtocol);
}