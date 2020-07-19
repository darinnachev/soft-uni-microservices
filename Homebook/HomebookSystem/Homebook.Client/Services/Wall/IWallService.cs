using System.Threading.Tasks;
using Homebook.Client.Models.Wall;
using Refit;

namespace Homebook.Client.Services.Wall
{
    public interface IWallService
    {
        [Get("/Wall")]
        Task<WallResult> Get();
    }
}
