using Homebook.Models;

namespace Homebook.Statistics.Models.Statistics
{
    public class StatisticsOutputModel : IMapFrom<Homebook.Statistics.Data.Models.Statistics>
    {
        public int TotalLikes { get; set; }

        public int TotalPosts { get; set; }
    }
}
