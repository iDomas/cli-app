using partycli.Models.Entities;

namespace partycli.Services.Persistence;

public interface IServerPersistenceService
{
    IEnumerable<ServerModel> GetServers();
    Task<bool> SaveServers(IEnumerable<ServerModel> servers);
}