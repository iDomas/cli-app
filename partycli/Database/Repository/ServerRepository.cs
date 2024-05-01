using Microsoft.EntityFrameworkCore;
using partycli.Models.Entities;

namespace partycli.Database.Repository;

public class ServerRepository(PartyCliDbContext context) : IServerRepository
{
    public IQueryable<ServerModel> GetServers()
    {
        return context.Servers.AsQueryable();
    }

    public async Task AddServer(ServerModel server)
    {
        await context.Servers.AddAsync(server);
        await context.SaveChangesAsync();
    }

    public async Task AddServers(IEnumerable<ServerModel> servers)
    {
        await context.Servers.AddRangeAsync(servers);
        await context.SaveChangesAsync();
    }

    public async Task UpdateServerRange(IEnumerable<ServerModel> servers)
    {
        await Task.Run(() => context.Servers.UpdateRange(servers));
        await context.SaveChangesAsync();
    }
}