using System.ComponentModel.DataAnnotations;

namespace partycli.Models.Entities;

public class ServerModel
{
    [Key]
    public int Id { get; set; }
    public string Name { get; set; }
    public int Load { get; set; }
    public string Status { get; set; }
}