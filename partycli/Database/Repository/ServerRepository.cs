using Microsoft.EntityFrameworkCore;
using partycli.Models.Entities;

namespace partycli.Database.Repository;

public class ServerRepository(PartyCliDbContext context) : IServerRepository
{
    public async Task<ServerModel?> GetServerByIdAsync(int serverId)
    {
        return await context.Servers.Where(s => s.Id == serverId).FirstOrDefaultAsync();
    }

    public IQueryable<ServerModel> GetServers()
    {
        return context.Servers.AsQueryable();
    }

    public async Task AddServerAsync(ServerModel server)
    {
        await context.Servers.AddAsync(server);
        await context.SaveChangesAsync();
    }

    public async Task AddOrUpdateServersAsync(IEnumerable<ServerModel> servers)
    {
        var newServers = new List<ServerModel>();
        var savedServers = new List<ServerModel>();
        
        var savedServerIds = context.Servers
            .Where(server => servers.Select(s => s.Id).Contains(server.Id))
            .Select(server => server.Id)
            .ToList();
        
        servers
            .ToList()
            .ForEach(server =>
            {
                if (!savedServerIds.Contains(server.Id))
                    newServers.Add(server);
                if (savedServerIds.Contains(server.Id))
                    savedServers.Add(server);
            });
        
        await UpdateServerRange(savedServers);
        await context.Servers.AddRangeAsync(newServers);
        await context.SaveChangesAsync();
    }

    public async Task UpdateServerRange(IEnumerable<ServerModel> servers)
    {
        await Task.Run(() => context.Servers.UpdateRange(servers));
        await context.SaveChangesAsync();
    }
}