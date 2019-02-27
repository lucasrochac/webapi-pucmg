using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;

namespace web_api.Providers
{
    public class TokenJWT
    {
        private JwtSecurityToken token;
        internal TokenJWT(JwtSecurityToken token)
        {
            this.token = token;
        }
        
        public DateTime ValidTo => token.ValidTo;
        public string value => new JwtSecurityTokenHandler().WriteToken(this.token);
    }
}