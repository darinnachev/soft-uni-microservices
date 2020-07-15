using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Friends.Data.Models
{
    public class Friend
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string FriendUserId { get; set; }
    }
}
