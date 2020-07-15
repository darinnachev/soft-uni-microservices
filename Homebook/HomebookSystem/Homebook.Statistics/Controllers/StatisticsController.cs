using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homebook.Statistics.Models.Statistics;
using Homebook.Statistics.Services.Statistics;
using Homebook.Controllers;

namespace Homebook.Statistics.Controllers
{
    public class StatisticsController : ApiController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics)
            => this.statistics = statistics;

        [HttpGet]
        public async Task<StatisticsOutputModel> Full()
            => await this.statistics.Full();
    }
}
