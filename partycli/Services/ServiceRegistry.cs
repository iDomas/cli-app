﻿using Microsoft.Extensions.DependencyInjection;
using partycli.Database;
using partycli.Services.Api;
using partycli.Services.Persistence;

namespace partycli.Services;

public static class ServiceRegistry
{
    private static ServiceProvider _services;
    
    public static IServiceCollection RegisterServices()
    {
        return new ServiceCollection()
            .AddLogging()
            .AddPartyCliContext()
            .AddSingleton<INordVpnApiService, NordVpnApiService>()
            .AddSingleton<IServerPersistenceService, ServerPersistenceService>();
    }
}