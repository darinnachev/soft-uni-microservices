using AutoMapper;
using Homebook.Friends.Data;
using Homebook.Friends.Data.Models;
using Homebook.Friends.Models.Friends;
using Homebook.Services;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Friends.Services.Friends
{
    public class FriendsService : DataService<Friend>, IFriendsService
    {
        private readonly IMapper mapper;

        public FriendsService(FriendsDbContext db, IMapper mapper)
            : base(db)
            => this.mapper = mapper;

        public async Task<IEnumerable<GetFriendModel>> GetAllFriendsByUserId(string UserId)
        {
            var a = this
                .All()
                .Where(d => d.UserId == UserId);

            return await this.mapper.ProjectTo<GetFriendModel>(a).ToListAsync();
        }
    }
}
