using AutoMapper;
using Homebook.Posts.Data;
using Homebook.Posts.Models.Posts;
using Homebook.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Posts.Services.Posts
{
    public class PostsService : DataService<Homebook.Posts.Data.Models.Post>, IPostsService
    {
        private readonly IMapper mapper;

        public PostsService(PostsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<IEnumerable<PostDetailsOutputModel>> GetAllPostsByUserId(string UserId)
        {
            var a = this
                .All()
                .Where(d => d.UserId == UserId);

            return await this.mapper.ProjectTo<PostDetailsOutputModel>(a).ToListAsync();
       }
    }
}
