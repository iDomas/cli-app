using partycli.Database.init;
using Spectre.Console;
using Spectre.Console.Cli;

namespace partycli.cli;

public class ConfigCommand: AsyncCommand<ConfigCommand.ConfigCommandSettings>
{
    public sealed class ConfigCommandSettings : CommandSettings
    {
        [CommandOption("-c|--country <country>")]
        public string? country { get; set; }
    }
    
    public ConfigCommand(IInitDatabaseService initDbService)
    {
        initDbService.Init();
    }
    
    public override async Task<int> ExecuteAsync(CommandContext context, ConfigCommandSettings settings)
    {
        return 0;
    }
}