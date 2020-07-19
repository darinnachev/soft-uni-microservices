using System.Diagnostics;
using Homebook.Infrastructure;
using Homebook.Client.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Homebook.Client.Models;

namespace Homebook.Client.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (this.User.IsClient())
            {
                return this.RedirectToAction(nameof(WallController.Index), "Wall");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
            => View(new ErrorViewModel
            {
                RequestId = Activity.Current?.Id ?? this.HttpContext.TraceIdentifier
            });
    }
}
