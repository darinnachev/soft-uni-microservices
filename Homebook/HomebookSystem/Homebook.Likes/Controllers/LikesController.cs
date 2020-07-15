using Homebook.Controllers;
using Homebook.Likes.Data.Models;
using Homebook.Likes.Models.Likes;
using Homebook.Likes.Services.Likes;
using Homebook.Services.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Likes.Controllers
{
    public class LikesController : ApiController
    {
        private readonly ILikesService likes;
        private readonly ICurrentUserService currentUser;

        public LikesController(
            ILikesService likes,
            ICurrentUserService currentUser)
        {
            this.likes = likes;
            this.currentUser = currentUser;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<bool>> Create(AddLikeModel input)
        {
            var like = new Like
            {
                PostId = input.PostId,
                UserId = this.currentUser.UserId
            };

            await this.likes.Save(like);

            //TODO Send MEssage for notification
            return true;
        }

        [HttpGet]
        [Authorize]
        [Route(Id)]
        public async Task<GetLikesByPostModel> GetLikesByPostId(int Id)
        {
            return await likes.GetLikesByPostId(Id);
        }

    }
}
