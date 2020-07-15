using Homebook.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Homebook.Posts.Data
{
    public class PostsDbContext : MessageDbContext
    {
        public PostsDbContext(DbContextOptions<PostsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Homebook.Posts.Data.Models.Post> Posts { get; set; }

        protected override Assembly ConfigurationsAssembly => Assembly.GetExecutingAssembly();

    }
}
