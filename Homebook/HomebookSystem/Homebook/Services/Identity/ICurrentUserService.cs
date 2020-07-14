using System;
using System.Collections.Generic;
using System.Text;

namespace Homebook.Services.Identity
{
    public interface ICurrentUserService
    {
        string UserId { get; }

        bool IsAdministrator { get; }
    }
}
