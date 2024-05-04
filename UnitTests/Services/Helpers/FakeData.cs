using partycli.Models.Entities;

namespace UnitTests.Services.Helpers;

public static class FakeData
{
    public static IEnumerable<ServerModel> FakeServers()
    {
        return new List<ServerModel>
        {
            new ServerModel { Id = 1, Name = "Test1" },
            new ServerModel { Id = 2, Name = "Test2" }
        };
    }
}