using Microsoft.EntityFrameworkCore;
using Spectre.Console;

namespace partycli.Database.init;

public class InitDatabaseService(PartyCliDbContext context) : IInitDatabaseService
{
    private static bool _isInitialized;
    
    public void Init()
    {
        if (_isInitialized) return;
        _isInitialized = true;
        context.Database.Migrate(); 
        AnsiConsole.MarkupLine("[green]Context initialized...[/]");
    }
}