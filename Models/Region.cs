using System.ComponentModel.DataAnnotations;

namespace MuntiRomania.Models;

public class Region
{
    public int RegionId { get; set; }

    [Required, StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [StringLength(500)]
    public string? Description { get; set; }
}
