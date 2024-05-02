

using partycli.Models.Entities;

namespace partycli.Database.Repository;

public interface IConfigRepository
{
    Task<ConfigModel?> GetActiveConfigAsync();
    Task SaveConfigAsActiveAsync(int serverId);
}