using System.Threading.Tasks;
using Homebook.Client.Models.Identity;
using Refit;


namespace Homebook.Client.Services.Identity
{
    public interface IIdentityService
    {
        [Post("/Identity/Login")]
        Task<UserOutputModel> Login([Body] UserInputModel loginInput);
    }
}
