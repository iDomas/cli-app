using Microsoft.Extensions.DependencyInjection;
using partycli.Database.init;
using partycli.Database.Repository;

namespace partycli.Database;

public static class PartyCliDbExtension
{
    public static IServiceCollection AddPartyCliContext(this IServiceCollection services)
    {
        return
            services
                .AddDbContext<PartyCliDbContext>()
                .AddSingleton<IInitDatabaseService, InitDatabaseService>()
                .AddSingleton<ILogRepository, LogRepository>()
                .AddSingleton<IServerRepository, ServerRepository>()
                .AddSingleton<IConfigRepository, ConfigRepository>();
    }
}