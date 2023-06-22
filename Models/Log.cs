namespace Models;

using System;
using System.ComponentModel.DataAnnotations.Schema;

public class Log: Base
{
    [Column(TypeName = "text")]
    public string message { get; set; } = String.Empty;
    public DateTime date { get; set; } = DateTime.Now;
}