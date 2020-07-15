using Homebook.Controllers;
using Homebook.Friends.Data.Models;
using Homebook.Friends.Models.Friends;
using Homebook.Friends.Services.Friends;
using Homebook.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Friends.Controllers
{
    public class FriendsController : ApiController
    {
        private readonly IFriendsService friends;
        private readonly ICurrentUserService currentUser;

        public FriendsController(
            IFriendsService friends,
            ICurrentUserService currentUser)
        {
            this.friends = friends;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create(AddFriendModel input)
        {
            var friend = new Friend
            {
               FriendUserId = input.FriendUserId,
                UserId = this.currentUser.UserId
            };

            await this.friends.Save(friend);

            // todo send message

            return friend.Id;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<GetFriendModel>> GetFriendsByUserId()
        {
            return await friends.GetAllFriendsByUserId(this.currentUser.UserId);
        }

    }
}
