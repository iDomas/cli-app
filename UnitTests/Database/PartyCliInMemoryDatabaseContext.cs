using Microsoft.EntityFrameworkCore;

namespace UnitTests.Database;

public class PartyCliInMemoryDatabaseContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseInMemoryDatabase("PartyCliTest");
}