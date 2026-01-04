using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MountainTrailsApp.Models;

namespace MountainTrailsApp.Data
{
    public class TrailsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public TrailsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Trail>().Wait();
        }

        public Task<List<Trail>> GetTrailsAsync()
        {
            return _database.Table<Trail>().ToListAsync();
        }

        public Task<Trail> GetTrailAsync(int id)
        {
            return _database.Table<Trail>()
                            .Where(t => t.Id == id)
                            .FirstOrDefaultAsync();
        }

        public Task<int> SaveTrailAsync(Trail trail)
        {
            if (trail.Id != 0)
            {
                return _database.UpdateAsync(trail);
            }
            else
            {
                return _database.InsertAsync(trail);
            }
        }

        public Task<int> DeleteTrailAsync(Trail trail)
        {
            return _database.DeleteAsync(trail);
        }
    }
}
