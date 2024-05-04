using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace partycli.Models.Entities;

public class ServerModel
{
    [Key]
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("name")]
    public string Name { get; set; }
    [JsonPropertyName("load")]
    public int Load { get; set; }
    [JsonPropertyName("status")]
    public string Status { get; set; }

    public override string ToString()
    {
        return $"{Name} - {Status} - {Load}";
    }
}