using System.ComponentModel.DataAnnotations;

namespace MuntiRomania.Models;

public class PointOfInterest
{
    public int PointOfInterestId { get; set; }

    [Required, StringLength(150)]
    public string Name { get; set; } = string.Empty;

    public string? Type { get; set; } // cabana, lac, varf etc.

    public ICollection<TrailPoint> TrailPoints { get; set; } = new List<TrailPoint>();
}
