namespace MuntiRomania.Models;

public class TrailPoint
{
    public int TrailId { get; set; }
    public Trail Trail { get; set; } = null!;

    public int PointOfInterestId { get; set; }
    public PointOfInterest PointOfInterest { get; set; } = null!;
}
