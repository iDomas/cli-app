using FluentAssertions;
using Moq;
using partycli.Database.Repository;
using partycli.Models.Entities;
using partycli.Services.App;

namespace UnitTests.Database.Repository;

public class ConfigRepositoryTest
{
    private readonly PartyCliInMemoryDatabaseContext _context;
    private readonly IConfigRepository _configRepository;
    
    private readonly Mock<ILogService> _logServiceMock = new();
    
    public ConfigRepositoryTest()
    {
        _context = new PartyCliInMemoryDatabaseContext();

        if (!_context.Database.EnsureCreated())
            throw new AggregateException("InMemory database not created.");
                
        _configRepository = new ConfigRepository(_context, _logServiceMock.Object);
    }
    
    [Fact]
    public async Task When_GetActiveConfigAsync_ThenReturnNull()
    {
        var config = await _configRepository
            .GetActiveConfigAsync();

        config.Should().BeNull();
    }
    
    [Fact]
    public async Task When_SaveConfigAsActiveAsync_ThenReturnConfig()
    {
        const int serverId = 1;
        await _configRepository.SaveConfigAsActiveAsync(serverId);
        
        var activeConfig = await _configRepository
            .GetActiveConfigAsync();
        
        activeConfig.Should().NotBeNull();
        activeConfig!.IsActive.Should().BeTrue();
        activeConfig.ServerId.Should().Be(1);
    }
}