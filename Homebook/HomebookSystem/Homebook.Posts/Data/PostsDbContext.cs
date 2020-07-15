using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Homebook.Posts.Data
{
    public class PostsDbContext : DbContext
    {
        public PostsDbContext(DbContextOptions<PostsDbContext> options)
            : base(options)
        {
        }

        public DbSet<Homebook.Posts.Data.Models.Post> Posts { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
