using partycli.Models.Constant;

namespace partycli.Services.App;

public interface ILogService
{
    Task Log(ActionType action);
}