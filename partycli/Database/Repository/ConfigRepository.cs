using Microsoft.EntityFrameworkCore;
using partycli.Models.Constant;
using partycli.Models.Entities;
using partycli.Services.App;


namespace partycli.Database.Repository;

public class ConfigRepository(PartyCliDbContext context,
    ILogService logService) : IConfigRepository
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

        await logService.Log(ActionType.ConfigSaved);

        await context.SaveChangesAsync();
    }
}