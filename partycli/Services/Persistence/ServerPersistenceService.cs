using partycli.Database.Repository;
using partycli.Models.Entities;

namespace partycli.Services.Persistence;

public class ServerPersistenceService(IServerRepository serverRepository) : IServerPersistenceService
{
    public IEnumerable<ServerModel> GetServers()
    {
        return serverRepository.GetServers().AsEnumerable();
    }

    public Task<bool> SaveServers(IEnumerable<ServerModel> servers)
    {
        throw new NotImplementedException();
    }
}