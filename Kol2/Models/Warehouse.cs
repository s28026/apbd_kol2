
using System.ComponentModel.DataAnnotations;

namespace Kol2.Models;

public class Warehouse
{
    [Key]
    public int Id { get; set; }

    [MaxLength(50)] public string Name { get; set; } = string.Empty;

    public ICollection<Object> Objects { get; set; } = new HashSet<Object>();
}