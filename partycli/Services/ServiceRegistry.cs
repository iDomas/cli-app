using Microsoft.Extensions.DependencyInjection;
using partycli.Database;

namespace partycli.Services;

public static class ServiceRegistry
{
    private static ServiceProvider _services;
    
    public static IServiceCollection RegisterServices()
    {
        return new ServiceCollection()
            .AddLogging()
            .AddDbContext<PartyCliDbContext>();
    }
}