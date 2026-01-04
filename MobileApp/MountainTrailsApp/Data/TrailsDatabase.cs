using SQLite;
using System.Collections.Generic;
using System.Threading.Tasks;
using MountainTrailsApp.Models;
using TrailRegion = MountainTrailsApp.Models.Region;


namespace MountainTrailsApp.Data
{
    public class TrailsDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public TrailsDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Trail>().Wait();
            _database.CreateTableAsync<TrailRegion>().Wait();
            _database.CreateTableAsync<HikeLog>().Wait();
            _database.CreateTableAsync<User>().Wait();
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

        public Task<List<TrailRegion>> GetRegionsAsync()
        {
            return _database.Table<TrailRegion>().ToListAsync();
        }

        public Task<int> SaveRegionAsync(TrailRegion region)
        {
            if (region.ID != 0)
                return _database.UpdateAsync(region);
            else
                return _database.InsertAsync(region);
        }

        public Task<int> DeleteRegionAsync(TrailRegion region)
        {
            return _database.DeleteAsync(region);
        }

        public Task<List<HikeLog>> GetHikeLogsForTrailAsync(int trailId)
        {
            return _database.Table<HikeLog>()
                            .Where(h => h.TrailId == trailId)
                            .OrderByDescending(h => h.Date)
                            .ToListAsync();
        }

        public Task<int> SaveHikeLogAsync(HikeLog log)
        {
            if (log.Id != 0)
                return _database.UpdateAsync(log);
            else
                return _database.InsertAsync(log);
        }

        public Task<int> DeleteHikeLogAsync(HikeLog log)
        {
            return _database.DeleteAsync(log);
        }

        public Task<User> GetUserByEmailAsync(string email)
        {
            return _database.Table<User>()
                .Where(u => u.Email == email)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveUserAsync(User user)
        {
            if (user.Id != 0) return _database.UpdateAsync(user);
            return _database.InsertAsync(user);
        }


    }
}
