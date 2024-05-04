using System.ComponentModel;
using partycli.cli.Helpers;
using partycli.Database.init;
using partycli.Models;
using partycli.Models.Enums;
using partycli.Services.UI;
using Spectre.Console.Cli;

namespace partycli.cli;

public sealed class ServerListCommand : Command<ServerListCommand.ServerListCommandSettings>
{
    public sealed class ServerListCommandSettings : CommandSettings
    {
        [CommandOption("-t|--TCP")]
        [Description("TCP option")]
        public bool? TcpOption { get; set; }
        
        [CommandOption("-l|--local")]
        [Description("Local option")]
        public bool? LocalOption { get; set; }
        
        [CommandOption("-c|--country <country>")]
        [Description("Country option")]
        public string? CountryOption { get; set; }
    }
    
    private readonly IUiService _uiService;
    
    public ServerListCommand(
        IInitDatabaseService initDbService,
        IUiService uiService)
    {
        initDbService.Init();
        _uiService = uiService;
    }
    
    public override int Execute(CommandContext context, ServerListCommandSettings settings)
    {
        if (settings.TcpOption == true)
        {
            _uiService.DisplayServers(
                new DisplayQuery(DisplayType.TcpServers, CountryCode.None, Protocol.TCP));
            return 0;
        }
        
        if (settings.LocalOption == true)
        {
            _uiService.DisplayServers(new DisplayQuery(DisplayType.LocalServers));
            return 0;
        }
        
        if (!string.IsNullOrWhiteSpace(settings.CountryOption))
        {
            _uiService.DisplayServers(new DisplayQuery(
                DisplayType.CountryServers,
                CountryCodeHelper.GetCountry(settings.CountryOption)));
            return 0;
        }

        _uiService.DisplayServers(
            new DisplayQuery(DisplayType.AllServers));
        return 0;
    }
}
