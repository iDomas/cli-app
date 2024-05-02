using FluentAssertions;
using partycli.Database.Repository;
using partycli.Models.Entities;

namespace UnitTests.Database.Repository;

public class LogRepositoryTest
{
    private readonly PartyCliInMemoryDatabaseContext _context;
    private readonly ILogRepository _logRepository;
    
    public LogRepositoryTest()
    {
        _context = new PartyCliInMemoryDatabaseContext();

        if (!_context.Database.EnsureCreated())
            throw new AggregateException("InMemory database not created.");
                
        _logRepository = new LogRepository(_context);
    }
    
    [Fact]
    public void When_GetLogs_ThenReturnEmpty()
    {
        var logs = _logRepository
            .GetLogs()
            .ToList();

        logs.Should().BeEmpty();
    }
    
    [Fact]
    public async Task When_AddLog_ThenReturnLog()
    {
        var log = new LogModel()
        {
            Action = 1,
            Time = DateTime.Now
        };
        
        await _logRepository.AddLog(log);
        
        var logs = _logRepository
            .GetLogs()
            .ToList();

        logs.Should().NotBeEmpty();
        logs.Should().HaveCount(1);
        logs.First().Action.Should().Be(1);
    }
}