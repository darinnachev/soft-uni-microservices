using System.Threading.Tasks;
using AutoMapper;
using Homebook.Services;
using Homebook.Statistics.Data;
using Microsoft.EntityFrameworkCore;
using Homebook.Statistics.Models.Statistics;

namespace Homebook.Statistics.Services.Statistics
{
    public class StatisticsService : DataService<Homebook.Statistics.Data.Models.Statistics>, IStatisticsService
    {
        private readonly IMapper mapper;

        public StatisticsService(StatisticsDbContext db, IMapper mapper)
            : base(db)
        {
            this.mapper = mapper;
        }

        public async Task<StatisticsOutputModel> Full()
            => await this.mapper
                .ProjectTo<StatisticsOutputModel>(this.All())
                .SingleOrDefaultAsync();

        public async Task AddPost()
        {
            var statistics = await this.All().SingleOrDefaultAsync();

            statistics.TotalPosts++;

            await this.Data.SaveChangesAsync();
        }
    }
}
