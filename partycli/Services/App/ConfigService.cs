using partycli.Database.Repository;
using partycli.Models.Entities;

namespace partycli.Services.App;

public class ConfigService(IConfigRepository configRepository) : IConfigService
{
    public async Task<ConfigModel?> LoadConfigAsync()
    {
        return await configRepository.GetActiveConfigAsync();
    }

    public async Task SaveConfigAsync(ServerModel server)
    {
        await configRepository.SaveConfigAsActiveAsync(server.Id);
    }
}