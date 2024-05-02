using FluentAssertions;
using Moq;
using partycli.cli;
using partycli.Database.init;
using Spectre.Console.Testing;

namespace UnitTests.Cli;

public class ConfigCommandTest
{
    private readonly Mock<IInitDatabaseService> _initDatabaseServiceMock = new();
    
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