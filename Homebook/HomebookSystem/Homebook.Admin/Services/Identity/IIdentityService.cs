using System.Threading.Tasks;
using Homebook.Admin.Models.Identity;
using Refit;

namespace Homebook.Admin.Services.Identity
{
    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
