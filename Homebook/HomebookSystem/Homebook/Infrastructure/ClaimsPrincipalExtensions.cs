using System.Security.Claims;
using static Homebook.Constants;

namespace Homebook.Infrastructure
{
    public static class ClaimsPrincipalExtensions
    {
        public static bool IsAdministrator(this ClaimsPrincipal user)
        {
            var res = user.IsInRole(AdministratorRoleName);

            return res;
        }
    }
}
