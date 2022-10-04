using Approval_Api.DataModel_.entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Collections.Generic;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System;

namespace Approval_Api.Services
{
    public class TokenServices : ITokenServices
    {
        public readonly SymmetricSecurityKey _symmetricSecurityKey;

        public TokenServices(IConfiguration configuration)
        {

            _symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["TokenKey"]));
        }
        public string CreateToken(Employee userInfo)
        {
            var claim = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, userInfo.Email),
                new Claim("userid", userInfo.UserId.ToString(CultureInfo.InvariantCulture)),
                new Claim("userTypeId", userInfo.UserId.ToString(CultureInfo.InvariantCulture)),
                new Claim(ClaimTypes.Role,userInfo.UserId.ToString(CultureInfo.InvariantCulture)),
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
