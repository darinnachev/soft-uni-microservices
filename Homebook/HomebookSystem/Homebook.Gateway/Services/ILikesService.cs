using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homebook.Gateway.Models;
using Refit;

namespace Homebook.Gateway.Services
{
    public interface ILikesService
    {
        [Get("/Likes/{PostId}")]
        Task<GetLikesByPostModel> Get(int PostId);
    }
}
