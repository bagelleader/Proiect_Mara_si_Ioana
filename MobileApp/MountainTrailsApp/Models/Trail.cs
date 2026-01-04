using SQLite;
using SQLiteNetExtensions.Attributes;


namespace MountainTrailsApp.Models
{
    public class Trail
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [MaxLength(200), Unique]
        public string Name { get; set; }       

        public string Difficulty { get; set; }    

        public double DurationHours { get; set; } 

        public double DistanceKm { get; set; }   

        public string Region { get; set; }

        [ForeignKey(typeof(Region))]
        public int RegionID { get; set; }


        public string Description { get; set; }
    }
}
