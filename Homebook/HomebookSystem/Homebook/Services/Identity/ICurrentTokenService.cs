using System;
using System.Collections.Generic;
using System.Text;

namespace Homebook.Services.Identity
{
    public interface ICurrentTokenService
    {
        string Get();

        void Set(string token);
    }
}
