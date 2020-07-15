using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Gateway.Models
{
    public class WallResult
    {
        public WallResult()
        {
            Posts = new List<PostWithLikesDetailsOutputModel>();
        }
        public List<PostWithLikesDetailsOutputModel> Posts { get; set; }
    }
}
