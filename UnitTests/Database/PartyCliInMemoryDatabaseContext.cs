using Microsoft.EntityFrameworkCore;
using partycli.Database;

namespace UnitTests.Database;

public class PartyCliInMemoryDatabaseContext : PartyCliDbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase($"PartyCliTest-{Guid.NewGuid()}");
    
}