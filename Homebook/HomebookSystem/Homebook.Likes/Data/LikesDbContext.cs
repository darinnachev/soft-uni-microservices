using Homebook.Likes.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Homebook.Likes.Data
{
    public class LikesDbContext : DbContext
    {
        public LikesDbContext(DbContextOptions<LikesDbContext> options)
            : base(options)
        {
        }

        public DbSet<Like> Likes { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
