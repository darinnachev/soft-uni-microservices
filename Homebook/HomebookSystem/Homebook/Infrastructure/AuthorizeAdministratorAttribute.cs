using Microsoft.AspNetCore.Authorization;

namespace Homebook.Infrastructure
{
    public class AuthorizeAdministratorAttribute : AuthorizeAttribute
    {
        public AuthorizeAdministratorAttribute() => this.Roles = Constants.AdministratorRoleName;
    }
}
