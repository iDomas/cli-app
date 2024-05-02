using FluentAssertions;
using Moq;
using partycli.Database.Repository;
using partycli.Models.Entities;
using partycli.Services.Api;
using partycli.Services.App;

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
}