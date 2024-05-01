using Microsoft.EntityFrameworkCore;
using partycli.Models.Entities;

namespace partycli.Database;

public class PartyCliDbContext : DbContext
{
    public virtual DbSet<LogModel> Logs { get; set; }
    public virtual DbSet<ServerModel> Servers { get; set; }

    private readonly string FileName = "partycli.db";
    
    public PartyCliDbContext()
    {
    }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={GetLocalDbFilePath(FileName)}");
    
    private string GetLocalDbFilePath(string filename)
    {
        var path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        return Path.Combine(path, filename);
    }
}