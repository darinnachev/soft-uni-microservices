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

using static Homebook.Infrastructure.InfrastructureConstants;
namespace Homebook.Client.Controllers
{
    public class IdentityController : ClientController
    {
        private readonly IIdentityService identityService;
        private readonly IMapper mapper;

        public IdentityController(
            IIdentityService identityService,
            IMapper mapper)
        {
            this.identityService = identityService;
            this.mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginFormModel model)
            => await this.Handle(
                async () =>
                {
                    var result = await this.identityService
                        .Login(this.mapper.Map<UserInputModel>(model));

                    this.Response.Cookies.Append(
                        AuthenticationCookieName,
                        result.Token,
                        new CookieOptions
                        {
                            HttpOnly = true,
                            Secure = true,
                            MaxAge = TimeSpan.FromDays(1)
                        });
                },
                success: RedirectToAction(nameof(WallController.Index), "Wall"),
                failure: View("../Home/Index", model));

        [AuthorizeAdministrator]
        public IActionResult Logout()
        {
            this.Response.Cookies.Delete(AuthenticationCookieName);

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }
    }
}
