using Moq;
using partycli.Database.Repository;
using partycli.Models;
using partycli.Models.Constant;
using partycli.Models.Entities;
using partycli.Services.App;

namespace UnitTests.Services.App;

public class LogServiceTest
{
    private readonly Mock<ILogRepository> _logRepositoryMock = new();
    
    private readonly ILogService _logService;
    
    public LogServiceTest()
    {
        _logService = new LogService(
            _logRepositoryMock.Object
        );
    }
    
    [Fact]
    public async Task LogService_Log()
    {
        var logMessage = new LogMessage()
        {
            Action = ActionType.ServerSaved
        };
        
        await _logService.Log(logMessage);
        
        _logRepositoryMock.Verify(x => x.AddLog(It.IsAny<LogModel>()), Times.Once);
    }
    
}