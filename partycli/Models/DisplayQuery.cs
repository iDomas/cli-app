using partycli.Models.Enums;

namespace partycli.Models;

public class DisplayQuery(DisplayType displayType, 
    CountryCode countryCode = CountryCode.None, 
    Protocol vpnProtocol = Protocol.None)
{
    public DisplayType displayType { get; } = displayType;
    public CountryCode CountryCode { get; } = countryCode;
    public Protocol VpnProtocol { get; } = vpnProtocol;
}