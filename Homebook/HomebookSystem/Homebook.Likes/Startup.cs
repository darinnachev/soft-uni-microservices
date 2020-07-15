using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homebook.Infrastructure;
using Homebook.Likes.Data;
using Homebook.Likes.Services.Likes;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Homebook.Likes
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
          => services
              .AddWebService<LikesDbContext>(this.Configuration)
              .AddTransient<ILikesService, LikesService>();
        //.AddMessaging(this.Configuration);

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
            => app
                .UseWebService(env)
                .Initialize();
    }
}
