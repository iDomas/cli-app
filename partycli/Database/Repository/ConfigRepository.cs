using Microsoft.EntityFrameworkCore;
using partycli.Models.Entities;


namespace partycli.Database.Repository;

public class ConfigRepository(PartyCliDbContext context) : IConfigRepository
{
    public async Task<ConfigModel?> GetActiveConfigAsync()
    {
        return await context.Configs.SingleOrDefaultAsync(c => c.IsActive);
    }

    public async Task SaveConfigAsActiveAsync(int serverId)
    {
        await context.Configs.AddAsync(
            new ConfigModel
            {
                ServerId = serverId,
                IsActive = true
            });

        await context.SaveChangesAsync();
    }
}