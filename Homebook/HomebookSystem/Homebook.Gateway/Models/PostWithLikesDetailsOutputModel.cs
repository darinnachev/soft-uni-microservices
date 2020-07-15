using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Gateway.Models
{
    public class PostWithLikesDetailsOutputModel
    {
        public string User { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public int Likes { get; set; }
    }
}
