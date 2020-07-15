using AutoMapper;
using Homebook.Posts.Data;
using Homebook.Services;

namespace Homebook.Posts.Services.Posts
{
    public class PostsService : DataService<Homebook.Posts.Data.Models.Post>, IPostsService
    {
        private readonly IMapper mapper;

        public PostsService(PostsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

    }
}
