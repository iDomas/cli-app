using FluentAssertions;
using Moq;
using partycli.Models;
using partycli.Models.Entities;
using partycli.Models.Enums;
using partycli.Services.App;
using partycli.Services.UI;
using Spectre.Console;
using UnitTests.Services.Helpers;

namespace UnitTests.Services.UI;

public class UiServiceTest
{
    private readonly Mock<IServerService> _serverServiceMock = new();
    private readonly Mock<IConfigService> _configServiceMock = new();
    
    private readonly IUiService _uiService;
    
    public UiServiceTest()
    {
        _uiService = new UiService(
            _serverServiceMock.Object,
            _configServiceMock.Object
        );
    }
    
    [Theory]
    [InlineData(DisplayType.AllServers)]
    [InlineData(DisplayType.LocalServers)]
    [InlineData(DisplayType.CountryServers)]
    [InlineData(DisplayType.TcpServers)]
    public void UiService_DisplayServers_NoServers(DisplayType displayType)
    {
        _serverServiceMock.Setup(x => x.GetServersAsync())
            .ReturnsAsync(Enumerable.Empty<ServerModel>());

        var query = new DisplayQuery(DisplayType.AllServers);

        AnsiConsole.Record();
        _uiService.DisplayServers(query);
        var text = AnsiConsole.ExportText();
        
        text.Should().Contain("Error: There are no server data in local storage");
    }
    
    [Fact]
    public void UiService_DisplayServers_Servers()
    {
        _serverServiceMock.Setup(x => x.GetServersAsync())
            .ReturnsAsync(FakeData.FakeServers());

        var query = new DisplayQuery(DisplayType.AllServers);
        
        AssertDisplayServers(query);
    }
    
    [Fact]
    public void UiService_DisplayServers_LocalServers()
    {
        _serverServiceMock.Setup(x => x.GetLocalServersAsync())
            .ReturnsAsync(FakeData.FakeServers());

        var query = new DisplayQuery(DisplayType.LocalServers);
        
        AssertDisplayServers(query);
    }
    
    [Fact]
    public void UiService_DisplayServers_CountryServers()
    {
        _serverServiceMock.Setup(x => x.GetAllServerByCountryListAsync(It.IsAny<CountryCode>()))
            .ReturnsAsync(FakeData.FakeServers());

        var query = new DisplayQuery(DisplayType.CountryServers, CountryCode.France);
        
        AssertDisplayServers(query);
    }
    
    [Fact]
    public void UiService_DisplayServers_ProtocolServers()
    {
        _serverServiceMock.Setup(x => x.GetAllServerByProtocolListAsync(It.IsAny<Protocol>()))
            .ReturnsAsync(FakeData.FakeServers());

        var query = new DisplayQuery(DisplayType.CountryServers, CountryCode.France);
        
        AssertDisplayServers(query);
    }
    
    [Fact]
    public async Task When_DisplayCurrentConfig_ThenDisplayErrorNoConfig()
    {
        AnsiConsole.Record();
        _uiService.DisplayCurrentConfig();
        var text = AnsiConsole.ExportText();
        
        text.Should().Contain("Error: There are no active configuration...");
    }
    
    [Fact]
    public async Task When_DisplayCurrentConfig_ThenDisplayErrorNoServer()
    {
        var config = new ConfigModel()
        {
            ServerId = 1
        };
        
        _configServiceMock.Setup(x => x.LoadConfigAsync())
            .ReturnsAsync(config);
        
        AnsiConsole.Record();
        _uiService.DisplayCurrentConfig();
        var text = AnsiConsole.ExportText();
        
        text.Should().Contain("Error: Config exists, but no such server...");
    }
    
    [Fact]
    public async Task When_DisplayCurrentConfig_ThenDisplayCurrentConfig()
    {
        var config = new ConfigModel()
        {
            ServerId = 1
        };
        
        var server = new ServerModel()
        {
            Id = 1,
            Name = "Test"
        };
        
        _configServiceMock.Setup(x => x.LoadConfigAsync())
            .ReturnsAsync(config);
        _serverServiceMock.Setup(x => x.GetServerByIdAsync(It.IsAny<int>()))
            .ReturnsAsync(server);
        
        AnsiConsole.Record();
        _uiService.DisplayCurrentConfig();
        var text = AnsiConsole.ExportText();
        
        text.Should().Contain($"Current server: {server.Name}");
    }
    
    private void AssertDisplayServers(DisplayQuery query)
    {
        
        AnsiConsole.Record();
        _uiService.DisplayServers(query);
        var text = AnsiConsole.ExportText();
        
        text.Should().Contain(FakeData.FakeServers().First().Name);
        text.Should().Contain(FakeData.FakeServers().Last().Name);
        text.Should().Contain("Total servers: 2");
    }
}