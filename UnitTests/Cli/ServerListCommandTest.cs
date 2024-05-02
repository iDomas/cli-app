using System.Runtime.CompilerServices;
using partycli.cli;
using Spectre.Console.Testing;
using FluentAssertions;
using Moq;
using partycli.Database.init;
using partycli.Services.App;
using Spectre.Console.Cli;

namespace UnitTests.Cli;

public class ServerListCommandTest
{
    private readonly Mock<IServerService> _serverServiceMock = new();
    private readonly Mock<IInitDatabaseService> _initDatabaseServiceMock = new();
    
    private readonly IRemainingArguments _remainingArgs = new Mock<IRemainingArguments>().Object;
    
    public ServerListCommandTest()
    {
        _initDatabaseServiceMock.Setup(x => x.Init());
    }

    [Fact]
    public void ServerListCommand_Return_0()
    {
        var app = new CommandAppTester();
        app.Configure(config =>
        {
            config.AddCommand<ServerListCommand>("server_list");
        });

        var result = app.Run();

        result.ExitCode.Should().Be(0);
    }
    
    [Theory]
    [InlineData("server_list")]
    [InlineData("server_list", "-t")]
    [InlineData("server_list", "--TCP")]
    [InlineData("server_list", "-l")]
    [InlineData("server_list", "--local")]
    [InlineData("server_list", "-c", "US")]
    [InlineData("server_list", "--country", "US")]
    public async Task ServerListCommand_ServerListWithOptions_Return_0(params string[] args)
    {
        var command = new ServerListCommand(
            _serverServiceMock.Object, 
            _initDatabaseServiceMock.Object
        );
        
        var context = new CommandContext(args, _remainingArgs, "server_list", null);

        var result = await command.ExecuteAsync(context, new ServerListCommand.ServerListCommandSettings());
        
        result.Should().Be(0);
    }
    
}