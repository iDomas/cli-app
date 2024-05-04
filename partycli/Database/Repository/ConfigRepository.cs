using Microsoft.EntityFrameworkCore;
using partycli.Models;
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
        SetLastInactive();
        
        await context.Configs.AddAsync(
            new ConfigModel
            {
                ServerId = serverId,
                IsActive = true
            });

        await logService.Log(new LogMessage()
        {
            Action = ActionType.ConfigSaved,
            MessageParam = serverId.ToString()
        });

        await context.SaveChangesAsync();
    }

    private void SetLastInactive()
    {
        var lastExists = context.Configs.Any();
        if (lastExists == false) return;
        var last = context.Configs.Last();
        last.IsActive = false;
        context.Configs.Update(last);
        context.SaveChanges();
    }
}