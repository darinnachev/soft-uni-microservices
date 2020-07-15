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

namespace Homebook.Posts.Controllers
{
    public class PostsController : ApiController
    {
        private readonly IPostsService posts;
        private readonly ICurrentUserService currentUser;

        public PostsController(
            IPostsService posts,
            ICurrentUserService currentUser)
        {
            this.posts = posts;
            this.currentUser = currentUser;
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

            // todo send message

            return post.Id;
        }

        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<PostDetailsOutputModel>> GetPostByUserId()
        {
            return await posts.GetAllPostsByUserId(this.currentUser.UserId);
        }

    }
}
