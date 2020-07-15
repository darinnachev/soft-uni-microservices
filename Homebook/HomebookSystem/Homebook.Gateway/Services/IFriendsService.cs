using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homebook.Gateway.Models;
using Refit;

namespace Homebook.Gateway.Services
{
    public interface IFriendsService
    {
        [Get("/Friends")]
        Task<IEnumerable<GetFriendModel>> Get();

    }
}
