using System.ComponentModel.DataAnnotations;

namespace MuntiRomania.Models;

public class Trail
{
    public int TrailId { get; set; }

    [Required, StringLength(150)]
    public string Name { get; set; } = string.Empty;

    [Required]
    public string Difficulty { get; set; } = string.Empty;

    public int LengthKm { get; set; }
    public int DurationHours { get; set; }

    [Required]
    public int MountainRangeId { get; set; }
    public MountainRange? MountainRange { get; set; }
    public ICollection<TrailPoint> TrailPoints { get; set; } = new List<TrailPoint>();
}
