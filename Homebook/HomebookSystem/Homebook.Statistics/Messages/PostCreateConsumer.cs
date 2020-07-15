using Homebook.Messages;
using Homebook.Statistics.Services.Statistics;
using MassTransit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Statistics.Messages
{
    public class PostCreateConsumer : IConsumer<PostCreateMessageModel>
    {
        private readonly IStatisticsService statistics;

        public PostCreateConsumer(IStatisticsService statistics)
            => this.statistics = statistics;

        public async Task Consume(ConsumeContext<PostCreateMessageModel> context)
        {
           await statistics.AddPost();

        }
    }
}
