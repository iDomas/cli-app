using FluentAssertions;
using Moq;
using partycli.cli;
using partycli.Database.init;
using partycli.Services.UI;
using Spectre.Console.Cli;
using Spectre.Console.Testing;

namespace UnitTests.Cli;

public class ServerListCommandTest
{
    private readonly Mock<IInitDatabaseService> _initDatabaseServiceMock = new();
    private readonly Mock<IUiService> _uiServiceMock = new();
    
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
    public void ServerListCommand_ServerListWithOptions_Return_0(params string[] args)
    {
        var command = new ServerListCommand(
            _initDatabaseServiceMock.Object,
            _uiServiceMock.Object
        );
        
        var context = new CommandContext(args, _remainingArgs, "server_list", null);

        var result = command.Execute(context, new ServerListCommand.ServerListCommandSettings());
        
        result.Should().Be(0);
    }
    
}