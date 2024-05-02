namespace partycli.Models.Constant;

public static class Action
{
    
    public static Dictionary<ActionType, string> ActionsMap = new Dictionary<ActionType, string>()
    {
        { ActionType.ServerSaved, "Saved new server list"}
    };
    
}

public enum ActionType
{
    ServerSaved = 0
}  