using FluentAssertions;
using partycli.cli;
using Spectre.Console.Testing;

namespace UnitTests.Cli;

public class ConfigCommandTest
{
    [Fact]
    public void ConfigCommand_Config_Return_0()
    {
        var app = new CommandAppTester();
        app.Configure(config =>
        {
            config.AddCommand<ConfigCommand>("config");
        });

        var result = app.Run();

        result.ExitCode.Should().Be(0);
    }
    
    [Fact]
    public void ConfigCommand_Config_CountryOption_Return_0()
    {
        var app = new CommandAppTester();
        app.Configure(config =>
        {
            config.AddCommand<ConfigCommand>("config");
        });

        var result = app.Run();

        result.ExitCode.Should().Be(0);
    }
}