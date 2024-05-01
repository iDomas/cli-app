﻿using System.ComponentModel.DataAnnotations;

namespace partycli.Models.Entities;

public class LogModel
{
    [Key]
    public int Id { get; set; }
    public string Action { get; set; }
    public DateTime Time { get; set; }
}