using partycli.Database.Repository;
using partycli.Models.Constant;
using partycli.Models.Entities;

namespace partycli.Services.App;

public class LogService(ILogRepository logRepository) : ILogService
{
    public async Task Log(ActionType action)
    {
        await logRepository.AddLog(new LogModel()
        {
            Action = (int)action,
            Time = DateTime.Now
        });
    }
}