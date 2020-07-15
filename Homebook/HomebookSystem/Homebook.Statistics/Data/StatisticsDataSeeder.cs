using System.Linq;
using Homebook.Services;
using Homebook.Statistics.Models;

namespace Homebook.Statistics.Data
{
    public class StatisticsDataSeeder : IDataSeeder
    {
        private readonly StatisticsDbContext db;

        public StatisticsDataSeeder(StatisticsDbContext db) => this.db = db;

        public void SeedData()
        {
            if (this.db.Statistics.Any())
            {
                return;
            }

            this.db.Statistics.Add(new Homebook.Statistics.Data.Models.Statistics
            {
                TotalLikes = 0,
                TotalPosts = 0
            });

            this.db.SaveChanges();
        }
    }
}
