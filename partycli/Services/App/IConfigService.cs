using partycli.Models.Entities;

namespace partycli.Services.App;

public interface IConfigService
{
    Task<ConfigModel?> LoadConfigAsync();
    Task SaveConfigAsync(ServerModel server);
}