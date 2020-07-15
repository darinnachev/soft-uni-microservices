using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Likes.Data.Models
{
    public class Like
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public int PostId{ get; set; }
    }
}
