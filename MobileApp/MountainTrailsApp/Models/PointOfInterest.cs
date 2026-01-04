using SQLite;

namespace MountainTrailsApp.Models
{
    public class PointOfInterest
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int TrailId { get; set; }        

        [SQLite.MaxLength(200)]
        public string Name { get; set; }          

        [SQLite.MaxLength(100)]
        public string Type { get; set; }         

        public string Notes { get; set; }      
    }
}
