using partycli.cli;
using Spectre.Console.Testing;
using FluentAssertions;

namespace UnitTests.Cli;

public class ServerListCommandTest
{
    [Fact]
    public void RuntimeCommand_ServerList_Return_0()
    {
        var app = new CommandAppTester();
        app.Configure(config =>
        {
            config.AddCommand<ServerListCommand>("server_list");
        });

        var result = app.Run();

        result.ExitCode.Should().Be(0);
    }
    
    [Fact]
    public void RuntimeCommand_ServerList_With_Argument_Return_0()
    {
        var app = new CommandAppTester();
        app.Configure(config =>
        {
            config.AddCommand<ServerListCommand>("server_list");
        });
        
        var args = new []{"server_list", "-t"}; 
        var result = app.Run(args);

        result.ExitCode.Should().Be(0);
    }
}