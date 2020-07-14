using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Homebook.Admin.Services.Statistics;

namespace Homebook.Admin.Controllers
{
    public class StatisticsController : AdministrationController
    {
        private readonly IStatisticsService statistics;

        public StatisticsController(IStatisticsService statistics)
            => this.statistics = statistics;

        public async Task<IActionResult> Index()
            => View(await this.statistics.Full());
    }
}
