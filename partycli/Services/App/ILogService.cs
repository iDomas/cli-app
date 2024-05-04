using partycli.Models;

namespace partycli.Services.App;

public interface ILogService
{
    Task Log(LogMessage logMessage);
}