﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;

namespace ReCapProject.Core.Utilities.Security.Encryption
{
    public static class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
        }
    }
}