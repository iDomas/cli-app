using partycli.Models.Constant;

namespace partycli.Models;

public class LogMessage
{
    public ActionType Action { get; set; }
    public string? MessageParam { get; set; }
}