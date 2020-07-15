using Homebook.Controllers;
using Homebook.Gateway.Models;
using Homebook.Gateway.Services;
using Homebook.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq;
using MassTransit.Metadata;

namespace Homebook.Gateway.Controllers
{
    public class WallController : ApiController
    {
        private readonly ICurrentUserService currentUser;
        private readonly IFriendsService friends;
        private readonly IPostsService posts;
        private readonly ILikesService likes;

        public WallController(
            IFriendsService friends,
            IPostsService posts,
            ILikesService likes,
            ICurrentUserService currentUser
            )
        {
            this.friends = friends;
            this.posts = posts;
            this.likes = likes;
            this.currentUser = currentUser;
        }

        [HttpGet]
        [Authorize]
        public async Task<WallResult> Get()
        {
            WallResult result = new WallResult();

            // First Get All friends
            var a = await friends.Get();
            List<GetFriendModel> Friends = a.ToList();

            foreach(GetFriendModel friend in Friends)
            {
                var b = await posts.Get(friend.FriendUserId);

                List<PostDetailsOutputModel> Posts = b.ToList();

                foreach (PostDetailsOutputModel post in Posts)
                {
                    var c = await likes.Get(post.Id);

                    result.Posts.Add(new PostWithLikesDetailsOutputModel()
                    {
                        User = friend.FriendUserId,
                        Title = post.Title,
                        Text = post.Text,
                        Likes = c.Likes
                    });
                }
            }

            return result;
        }
    }
}
