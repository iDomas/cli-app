using partycli.Models.Entities;

namespace partycli.Database.Repository;

public class LogRepository(PartyCliDbContext context) : ILogRepository
{
    public IQueryable<LogModel> GetLogs()
    {
        return context.Logs.AsQueryable();
    }

    public void AddLog(LogModel log)
    {
        context.Logs.Add(log);
        context.SaveChanges();
    }
}