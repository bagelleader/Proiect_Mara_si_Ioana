using SQLite;

namespace MountainTrailsApp.Models
{
    public class User
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        [SQLite.MaxLength(200), SQLite.Unique]
        public string Email { get; set; }

        [SQLite.MaxLength(200)]
        public string PasswordHash { get; set; }

        [SQLite.MaxLength(200)]
        public string PasswordSalt { get; set; }

        // "User" sau "Admin"
        [SQLite.MaxLength(50)]
        public string Role { get; set; } = "User";
    }
}
