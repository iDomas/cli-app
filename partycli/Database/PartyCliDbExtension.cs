using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using partycli.Database.Repository;

namespace partycli.Database;

public static class PartyCliDbExtension
{
    public static IServiceCollection AddPartyCliContext(this IServiceCollection services)
    {
        return
            services
                .AddDbContext<PartyCliDbContext>()
                .AddSingleton<ILogRepository, LogRepository>()
                .AddSingleton<IServerRepository, ServerRepository>();
    }
}