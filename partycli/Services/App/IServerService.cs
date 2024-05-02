using partycli.Models.Entities;

namespace partycli.Services.App;

public interface IServerService
{
    Task<IEnumerable<ServerModel>> GetServers();
    Task<bool> SaveServers(IEnumerable<ServerModel> servers);
}