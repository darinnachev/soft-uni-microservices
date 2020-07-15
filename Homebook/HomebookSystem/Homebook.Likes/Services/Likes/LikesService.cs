using AutoMapper;
using Homebook.Likes.Data;
using Homebook.Likes.Data.Models;
using Homebook.Likes.Models.Likes;
using Homebook.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Likes.Services.Likes
{
    public class LikesService : DataService<Like>, ILikesService
    {
        private readonly IMapper mapper;

        public LikesService(LikesDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<GetLikesByPostModel> GetLikesByPostId(int PostId)
        {
            var List = await this
                .All()
                .Where(d => d.PostId == PostId)
                .ToListAsync();

            return new GetLikesByPostModel() { Likes = List.Count};
        }

    }
}
