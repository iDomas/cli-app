using partycli.Models.Entities;

namespace partycli.Database.Repository;

public interface ILogRepository
{
    IQueryable<LogModel> GetLogs();
    Task AddLog(LogModel log);
}