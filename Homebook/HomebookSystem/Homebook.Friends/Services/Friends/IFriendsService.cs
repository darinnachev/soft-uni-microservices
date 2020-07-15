using Homebook.Friends.Data.Models;
using Homebook.Friends.Models.Friends;
using Homebook.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Friends.Services.Friends
{
    public interface IFriendsService : IDataService<Friend>
    {
        Task<IEnumerable<GetFriendModel>> GetAllFriendsByUserId(string UserId);
    }
}
