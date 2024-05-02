namespace partycli.Models.Constant;

public static class Action
{
    
    public static Dictionary<ActionType, Func<string, string?>> ActionsMap = new()
    {
        { ActionType.ServerSaved, (_) => "Saved new server list"},
        { ActionType.ConfigSaved, (name) => $"Changed config to {name}"}
    };
    
}

public enum ActionType
{
    ServerSaved = 0,
    ConfigSaved = 1,
}  