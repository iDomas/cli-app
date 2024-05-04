using partycli.Models.Enums;
using Spectre.Console;

namespace partycli.cli.Helpers;

public static class CountryCodeHelper
{
    public static CountryCode GetCountry(string country)
    {
        var countries = Enum.GetNames<CountryCode>();
        if (!countries.Contains(country, StringComparer.OrdinalIgnoreCase))
        {
            AnsiConsole.MarkupLine($"[red]Invalid country code: {country}[/]");
            throw new ArgumentException("Invalid country code.");
        }
        var ignoreCase = country.ToLowerInvariant();
        return Enum.Parse<CountryCode>(ignoreCase, true);
    } 
}