using Homebook.Likes.Data.Models;
using Homebook.Likes.Models.Likes;
using Homebook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Likes.Services.Likes
{
    public interface ILikesService : IDataService<Like>
    {
        Task<GetLikesByPostModel> GetLikesByPostId(int PostId);
    }
}
