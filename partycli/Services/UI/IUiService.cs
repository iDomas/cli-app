using partycli.Models;

namespace partycli.Services.UI;

public interface IUiService
{
    void DisplayServers(DisplayQuery query);

    void DisplayConfigSelection();

    void DisplayCurrentConfig();
}