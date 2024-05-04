using partycli.Models.Entities;

namespace partycli.Database.Repository;

public interface IServerRepository
{
    Task<ServerModel?> GetServerByIdAsync(int serverId);
    IQueryable<ServerModel> GetServers();
    Task AddServerAsync(ServerModel server);
    Task AddOrUpdateServersAsync(IEnumerable<ServerModel> servers);
    Task UpdateServerRange(IEnumerable<ServerModel> servers);
}