using System.Threading.Tasks;
using Homebook.Services;
using Homebook.Identity.Data.Models;
using Homebook.Identity.Models.Identity;

namespace Homebook.Identity.Services.Identity
{
    public interface IIdentityService
    {
        Task<Result<User>> Register(UserInputModel userInput);

        Task<Result<UserOutputModel>> Login(UserInputModel userInput);
    }
}
