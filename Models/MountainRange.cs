using System.ComponentModel.DataAnnotations;

namespace MuntiRomania.Models;

public class MountainRange
{
    public int MountainRangeId { get; set; }

    [Required, StringLength(100, MinimumLength = 3)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public int RegionId { get; set; }

    public Region? Region { get; set; }
}
