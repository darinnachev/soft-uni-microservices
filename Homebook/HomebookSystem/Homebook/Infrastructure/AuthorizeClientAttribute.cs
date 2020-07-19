using Microsoft.AspNetCore.Authorization;

namespace Homebook.Infrastructure
{
    public class AuthorizeClientAttribute : AuthorizeAttribute
    {
        public AuthorizeClientAttribute() => this.Roles = Constants.ClientRoleName;
    }
}
