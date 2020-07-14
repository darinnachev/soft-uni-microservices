using System.Threading.Tasks;
using Homebook.Admin.Models.Statistics;
using Refit;

namespace Homebook.Admin.Services.Statistics
{
    public interface IStatisticsService
    {
        [Get("/Statistics")]
        Task<StatisticsOutputModel> Full();
    }
}
