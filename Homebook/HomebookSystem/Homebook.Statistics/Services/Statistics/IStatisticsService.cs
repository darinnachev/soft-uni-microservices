using System.Threading.Tasks;
using Homebook.Statistics.Models.Statistics;

namespace Homebook.Statistics.Services.Statistics
{
    public interface IStatisticsService
    {
        Task<StatisticsOutputModel> Full();

        Task AddPost();
    }
}
