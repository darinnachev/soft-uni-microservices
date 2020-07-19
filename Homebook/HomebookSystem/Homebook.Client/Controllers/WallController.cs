using System;
using System.Threading.Tasks;
using AutoMapper;
using Homebook.Infrastructure;
using Homebook.Client.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Homebook.Client.Models.Identity;
using Homebook.Client.Services.Identity;
using Homebook.Client.Services.Wall;

namespace Homebook.Client.Controllers
{
    public class WallController : ClientController
    {
        private readonly IIdentityService identityService;
        private readonly IMapper mapper;
        private readonly IWallService wall;

        public WallController(
            IIdentityService identityService,
            IMapper mapper,
            IWallService wall)
        {
            this.identityService = identityService;
            this.mapper = mapper;
            this.wall = wall;
        }

        public async Task<IActionResult> Index()
        {
            return View(await this.wall.Get());
        }
    }
}
