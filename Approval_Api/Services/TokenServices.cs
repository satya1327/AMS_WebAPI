using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;
using Approval_Api.DataModel_.entities;
using System.Threading.Tasks;

namespace Approval_Api.Services
{
    public class TokenServices : ITokenServices
    {
        public readonly SymmetricSecurityKey _symmetricSecurityKey;

        public TokenServices(IConfiguration configuration)
        {

            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
       

        public string CreateToken(UserModel userInfo)
        {
            var claim = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.UserName),
              new Claim("userid", userInfo.UserId.ToString()),
                new Claim("userTypeId", userInfo.UserName.ToString()),
                new Claim(ClaimTypes.Role, userInfo.RoleId.ToString()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
            var credential = new SigningCredentials(_symmetricSecurityKey, SecurityAlgorithms.HmacSha512Signature);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claim),
                Expires = DateTime.Now.AddDays(10),
                SigningCredentials = credential,
            };
            //validates the specified security token.
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
