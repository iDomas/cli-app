using System.ComponentModel.DataAnnotations;

namespace partycli.Models.Entities;

public class ConfigModel
{
    [Key]
    public int Id { get; set; }
    public int ServerId { get; set; }
    public bool IsActive { get; set; }
    
    public virtual ServerModel Server { get; set; }
}