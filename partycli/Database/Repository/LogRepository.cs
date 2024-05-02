using partycli.Models.Entities;

namespace partycli.Database.Repository;

public class LogRepository(PartyCliDbContext context) : ILogRepository
{
    public IQueryable<LogModel> GetLogs()
    {
        return context.Logs.AsQueryable();
    }

    public async Task AddLog(LogModel log)
    {
        await context.Logs.AddAsync(log);
        await context.SaveChangesAsync();
    }
}