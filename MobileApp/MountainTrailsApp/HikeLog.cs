using SQLite;

namespace MountainTrailsApp.Models
{
    public class HikeLog
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public int TrailId { get; set; }       

        public DateTime Date { get; set; }    

        public double DurationHours { get; set; }  

        public string Notes { get; set; }  
    }
}
