using Microsoft.EntityFrameworkCore;
using partycli.Models.Entities;

namespace partycli.Database;

public class PartyCliDbContext : DbContext
{
    public DbSet<LogModel> Logs { get; set; }
    public DbSet<ServerModel> Servers { get; set; }
    
    public string DbPath { get; }
    
    public PartyCliDbContext()
    {
        DbPath = Path.Join("./partycli.db");
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}