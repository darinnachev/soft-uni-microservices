using AutoMapper;
using Homebook.Friends.Data.Models;
using Homebook.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homebook.Friends.Models.Friends
{
    public class GetFriendModel: IMapFrom<Friend>
    {
        public string FriendUserId { get; set; }

        public virtual void Mapping(Profile mapper)
           => mapper
               .CreateMap<Friend, GetFriendModel>();
    }
}
