using partycli.Models.Entities;

namespace partycli.Database.Repository;

public interface IServerRepository
{
    IQueryable<ServerModel> GetServers();
    Task AddServer(ServerModel server);
    Task AddServers(IEnumerable<ServerModel> servers);
    Task UpdateServerRange(IEnumerable<ServerModel> servers);
}