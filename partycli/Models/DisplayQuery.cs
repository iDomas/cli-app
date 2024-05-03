using partycli.Models.Enums;

namespace partycli.Models;

public class DisplayQuery(DisplayType displayType, CountryCode countryCode)
{
    public DisplayType displayType { get; } = displayType;
    public CountryCode CountryCode { get; } = countryCode;
}