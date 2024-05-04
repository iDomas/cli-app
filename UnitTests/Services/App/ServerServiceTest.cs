using FluentAssertions;
using Moq;
using partycli.Database.Repository;
using partycli.Models.Entities;
using partycli.Models.Enums;
using partycli.Services.Api;
using partycli.Services.App;
using UnitTests.Services.Helpers;

namespace UnitTests.Services.App;

public class ServerServiceTest
{
    private readonly Mock<IServerRepository> _serverRepositoryMock = new();
    private readonly Mock<INordVpnApiService> _nordVpnApiServiceMock = new();
    private readonly Mock<ILogService> _logServiceMock = new();

    private readonly IServerService _serverService;

    public ServerServiceTest()
    {
        _serverService = new ServerService(
            _serverRepositoryMock.Object,
            _nordVpnApiServiceMock.Object,
            _logServiceMock.Object
        );
    }

    [Fact]
    public async Task When_GetAllServerListAsync_ThenEmptyList()
    {
        _serverRepositoryMock.Setup(x => x.GetServers())
            .Returns(Enumerable.Empty<ServerModel>().AsQueryable());
        _nordVpnApiServiceMock.Setup(x => x.GetAllServersListAsync())
            .ReturnsAsync(Enumerable.Empty<ServerModel>());

        var result = await _serverService.GetServersAsync();
        
        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public async Task When_GetAllServerListAsync_ThenList()
    {

        
        _serverRepositoryMock.Setup(x => x.GetServers())
            .Returns(FakeData.FakeServers().AsQueryable());
        _nordVpnApiServiceMock.Setup(x => x.GetAllServersListAsync())
            .ReturnsAsync(FakeData.FakeServers());

        var result = await _serverService.GetServersAsync();
        
        result.Should().NotBeNull();
        result.Count().Should().Be(2);
    }
    
    [Fact]
    public async Task When_GetAllServerLocalListAsync_ThenEmptyList()
    {
        _serverRepositoryMock.Setup(x => x.GetServers())
            .Returns(Enumerable.Empty<ServerModel>().AsQueryable());
        _nordVpnApiServiceMock.Setup(x => x.GetAllServersListAsync())
            .ReturnsAsync(Enumerable.Empty<ServerModel>());

        var result = await _serverService.GetLocalServersAsync();
        
        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public async Task When_GetAllServerLocalListAsync_ThenReturnList()
    {
        _serverRepositoryMock.Setup(x => x.GetServers())
            .Returns(FakeData.FakeServers().AsQueryable());
        _nordVpnApiServiceMock.Setup(x => x.GetAllServersListAsync())
            .ReturnsAsync(FakeData.FakeServers());

        var result = await _serverService.GetLocalServersAsync();
        
        result.Should().NotBeNull();
        result.Count().Should().Be(2);
    }

    [Fact]
    public async Task When_GetAllServerByCountryListAsync_ThenEmptyList()
    {
        _nordVpnApiServiceMock.Setup(x => x.GetAllServerByCountryListAsync(CountryCode.France))
            .ReturnsAsync(Enumerable.Empty<ServerModel>());

        var result = await _serverService.GetAllServerByCountryListAsync(CountryCode.France);
        
        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }    
    
    [Fact]
    public async Task When_GetAllServerByCountryListAsync_ThenReturnList()
    {
        _nordVpnApiServiceMock.Setup(x => x.GetAllServerByCountryListAsync(CountryCode.France))
            .ReturnsAsync(FakeData.FakeServers());

        var result = await _serverService.GetAllServerByCountryListAsync(CountryCode.France);
        
        result.Should().NotBeNull();
        result.Count().Should().Be(2);
    }
    
    [Fact]
    public async Task When_GetAllServerByProtocolListAsync_ThenEmptyList()
    {
        _nordVpnApiServiceMock.Setup(x => x.GetAllServerByProtocolListAsync(Protocol.TCP))
            .ReturnsAsync(Enumerable.Empty<ServerModel>());

        var result = await _serverService.GetAllServerByProtocolListAsync(Protocol.TCP);
        
        result.Should().NotBeNull();
        result.Count().Should().Be(0);
    }
    
    [Fact]
    public async Task When_GetAllServerByProtocolListAsync_ThenList()
    {
        _nordVpnApiServiceMock.Setup(x => x.GetAllServerByProtocolListAsync(Protocol.TCP))
            .ReturnsAsync(FakeData.FakeServers());

        var result = await _serverService.GetAllServerByProtocolListAsync(Protocol.TCP);
        
        result.Should().NotBeNull();
        result.Count().Should().Be(2);
    }
    
    [Fact]
    public async Task When_GetServerByIdAsync_ThenReturnServer()
    {
        var server = new ServerModel()
        {
            Load = 1,
            Name = "Test",
            Status = "offline"
        };
        
        _serverRepositoryMock.Setup(x => x.GetServerByIdAsync(1))
            .ReturnsAsync(server);

        var result = await _serverService.GetServerByIdAsync(1);
        
        result.Should().NotBeNull();
        result.Load.Should().Be(1);
        result.Name.Should().Be("Test");
        result.Status.Should().Be("offline");
    }
    
}