using AutoMapper;
using Homebook.Models;
using Homebook.Posts.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Posts.Models.Posts
{
    public class PostDetailsOutputModel : IMapFrom<Post>
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public virtual void Mapping(Profile mapper)
           => mapper
               .CreateMap<Post, PostDetailsOutputModel>();
    }
}
