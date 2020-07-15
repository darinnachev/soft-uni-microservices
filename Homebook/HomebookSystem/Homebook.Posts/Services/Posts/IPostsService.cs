using Homebook.Posts.Models.Posts;
using Homebook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Posts.Services.Posts
{
    public interface IPostsService : IDataService<Homebook.Posts.Data.Models.Post>
    {
        Task<IEnumerable<PostDetailsOutputModel>> GetAllPostsByUserId(string UserId);
    }
}
