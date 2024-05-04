using partycli.Database.init;
using partycli.Services.UI;
using Spectre.Console.Cli;

namespace partycli.cli;

public sealed class ConfigCommand: Command<ConfigCommand.ConfigCommandSettings>
{
    public sealed class ConfigCommandSettings : CommandSettings
    {
        [CommandOption("-c|--current")]
        public bool? Current { get; set; }
    }

    private readonly IUiService _uiService;
    
    public ConfigCommand(IInitDatabaseService initDbService,
        IUiService uiService)
    {
        initDbService.Init();
        _uiService = uiService;
    }
    
    public override int Execute(CommandContext context, ConfigCommandSettings settings)
    {
        if (settings.Current == true)
        {
            _uiService.DisplayCurrentConfig();
            return 0;
        }
        _uiService.DisplayConfigSelection();
        return 0;
    }
}