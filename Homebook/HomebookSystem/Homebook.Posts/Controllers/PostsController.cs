using System.Collections.Generic;
using System.Threading.Tasks;
using Homebook.Services;
using Homebook.Services.Identity;
using Homebook.Data.Models;
using Homebook.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Homebook.Controllers;
using Homebook.Posts.Models.Posts;
using Homebook.Posts.Data.Models;
using Homebook.Posts.Services.Posts;
using Homebook.Messages;
using MassTransit;

namespace Homebook.Posts.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPostsService posts;
        private readonly ICurrentUserService currentUser;
        private readonly IBus publisher;

        public PostsController(
            IPostsService posts,
            ICurrentUserService currentUser,
            IBus publisher)
        {
            this.posts = posts;
            this.currentUser = currentUser;
            this.publisher = publisher;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<int>> Create(AddPostModel input)
        {
            var post = new Post
            {
                Title = input.Title,
                Text = input.Text,
                UserId = this.currentUser.UserId
            };

            await this.posts.Save(post);

            var messageData = new PostCreateMessageModel()
            {
                UserId = this.currentUser.UserId,
                Title = input.Title
            };

            await publisher.Publish(messageData);

            return post.Id;
        }

        [HttpGet]
        [Authorize]
        [Route("{UserId?}")]
        public async Task<IEnumerable<PostDetailsOutputModel>> GetPostByUserId(string UserId)
        {
            if (string.IsNullOrEmpty(UserId))
                UserId = this.currentUser.UserId;

            return await posts.GetAllPostsByUserId(UserId);
        }

    }
}
