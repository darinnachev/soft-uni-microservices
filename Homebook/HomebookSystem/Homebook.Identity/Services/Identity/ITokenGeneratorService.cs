using System.Collections.Generic;
using Homebook.Identity.Data.Models;

namespace Homebook.Identity.Services.Identity
{
    public interface ITokenGeneratorService
    {
        string GenerateToken(User user, IEnumerable<string> roles = null);
    }
}
