using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Homebook.Infrastructure;
using Homebook.Client.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Refit;

namespace Homebook.Client.Controllers
{
    [AuthorizeClientAttribute]
    public class ClientController : Controller
    {
        protected async Task<ActionResult> Handle(Func<Task> action, ActionResult success, ActionResult failure)
        {
            try
            {
                await action();
                return success;
            }
            catch (ApiException exception)
            {
                this.ProcessErrors(exception);
                return failure;
            }
        }

        private void ProcessErrors(ApiException exception)
        {
            if (exception.HasContent)
            {
                JsonConvert
                    .DeserializeObject<List<string>>(exception.Content)
                    .ForEach(error => this.ModelState.AddModelError(string.Empty, error));
            }
            else
            {
                this.ModelState.AddModelError(string.Empty, "Internal server error.");
            }
        }
    }
}
