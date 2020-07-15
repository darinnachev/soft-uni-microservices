using Homebook.Infrastructure;
using Homebook.Services;
using Homebook.Statistics.Data;
using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Homebook.Statistics.Services.Statistics;

namespace Homebook.Statistics
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
           => services
               .AddWebService<StatisticsDbContext>(this.Configuration)
               .AddTransient<IDataSeeder, StatisticsDataSeeder>()
               .AddTransient<IStatisticsService, StatisticsService>();

               //.AddMessaging(
               //    this.Configuration,
               //    typeof(CarAdCreatedConsumer));

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
