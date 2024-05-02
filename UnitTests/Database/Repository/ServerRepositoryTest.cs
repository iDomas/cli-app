using FluentAssertions;
using partycli.Database.Repository;
using partycli.Models.Entities;

namespace UnitTests.Database.Repository;

public class ServerRepositoryTest
{
    private readonly PartyCliInMemoryDatabaseContext _context;
    private readonly IServerRepository _serverRepository;
    
    public ServerRepositoryTest()
    {
        _context = new PartyCliInMemoryDatabaseContext();

        if (!_context.Database.EnsureCreated())
            throw new AggregateException("InMemory database not created.");
                
        _serverRepository = new ServerRepository(_context);
    }
    
    [Fact]
    public void When_GetServers_ThenReturnEmpty()
    {
        var servers = _serverRepository
            .GetServers()
            .ToList();

        servers.Should().BeEmpty();
    }

    [Fact]
    public async Task When_AddServer_ThenReturnServer()
    {
        var server = new ServerModel()
        {
            Load = 1,
            Name = "Test",
            Status = "offline"
        };
        
        await _serverRepository.AddServer(server);
        
        var servers = _serverRepository
            .GetServers()
            .ToList();
        
        servers.Should().NotBeEmpty();
        servers.Should().HaveCount(1);
        servers.First().Load.Should().Be(1);
        servers.First().Name.Should().Be("Test");
        servers.First().Status.Should().Be("offline");
    }
    
    [Fact]
    public async Task When_AddServers_ThenReturnServers()
    {
        var servers = new List<ServerModel>()
        {
            new ServerModel()
            {
                Load = 1,
                Name = "Test1",
                Status = "offline"
            },
            new ServerModel()
            {
                Load = 2,
                Name = "Test2",
                Status = "online"
            }
        };
        
        await _serverRepository.AddServers(servers);
        
        var serversList = _serverRepository
            .GetServers()
            .ToList();
        
        serversList.Should().NotBeEmpty();
        serversList.Should().HaveCount(2);
        serversList.First().Load.Should().Be(1);
        serversList.First().Name.Should().Be("Test1");
        serversList.First().Status.Should().Be("offline");
        serversList.Last().Load.Should().Be(2);
        serversList.Last().Name.Should().Be("Test2");
        serversList.Last().Status.Should().Be("online");
    }
}