﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Homebook.Services.Identity
{
    public class CurrentTokenService : ICurrentTokenService
    {
        private string currentToken;

        public string Get() => this.currentToken;

        public void Set(string token) => this.currentToken = token;
    }
}
