using SQLite;
using SQLiteNetExtensions.Attributes;
using System.Collections.Generic;

namespace MountainTrailsApp.Models
{
    public class Region
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }

        public string Name { get; set; } 

        [OneToMany]
        public List<Trail> Trails { get; set; }
    }
}
