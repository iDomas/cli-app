using FluentAssertions;
using Moq;
using partycli.cli;
using partycli.Database.init;
using partycli.Services.UI;
using Spectre.Console.Cli;
using Spectre.Console.Testing;

namespace UnitTests.Cli;

public class ConfigCommandTest
{
    private readonly Mock<IInitDatabaseService> _initDatabaseServiceMock = new();
    private readonly Mock<IUiService> _uiServiceMock = new();
    
    private readonly IRemainingArguments _remainingArgs = new Mock<IRemainingArguments>().Object;
    
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
    
    [Theory]
    [InlineData("config", "-c")]
    [InlineData("config", "--current")]
    public void ConfigCommand_Config_CountryOption_Return_0(params string[] args)
    {
        var command = new ConfigCommand(
            _initDatabaseServiceMock.Object,
            _uiServiceMock.Object
        );
        
        var context = new CommandContext(args, _remainingArgs, "config", null);

        var result = command.Execute(context, new ConfigCommand.ConfigCommandSettings());
        
        result.Should().Be(0);
    }
}