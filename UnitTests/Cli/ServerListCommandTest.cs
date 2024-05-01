using partycli.cli;
using Spectre.Console.Testing;
using FluentAssertions;

namespace UnitTests.Cli;

public class ServerListCommandTest
{
    [Fact]
    public void ServerListCommand_ServerList_Return_0()
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
    public void ServerListCommand_ServerList_TcpOption_Return_0()
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
    
    [Fact]
    public void ServerListCommand_ServerList_LocalOption_Return_0()
    {
        var app = new CommandAppTester();
        app.Configure(config =>
        {
            config.AddCommand<ServerListCommand>("server_list");
        });
        
        var args = new []{"server_list", "-l"}; 
        var result = app.Run(args);

        result.ExitCode.Should().Be(0);
    }
    
    [Fact]
    public void ServerListCommand_ServerList_CountryOption_Return_0()
    {
        var app = new CommandAppTester();
        app.Configure(config =>
        {
            config.AddCommand<ServerListCommand>("server_list");
        });
        
        var args = new []{"server_list", "-c", "US"}; 
        var result = app.Run(args);

        result.ExitCode.Should().Be(0);
    }
}