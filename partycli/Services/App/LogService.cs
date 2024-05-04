using partycli.Database.Repository;
using partycli.Models;
using partycli.Models.Entities;
using Spectre.Console;
using Action = partycli.Models.Constant.Action;

namespace partycli.Services.App;

public class LogService(ILogRepository logRepository) : ILogService
{
    public async Task Log(LogMessage logMessage)
    {
        var ansiMessage = $"[green]{Action.ActionsMap[logMessage.Action](logMessage.MessageParam ?? "")}[/]";
        AnsiConsole.MarkupLine(ansiMessage);
        await logRepository.AddLog(new LogModel()
        {
            Action = (int)logMessage.Action,
            Time = DateTime.Now
        });
    }
}