using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;

namespace Approval_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService;
        private readonly IConfiguration _config;
        private readonly ITokenServices _tokenService;

        public LoginController(IConfiguration config, IAuthenticationServices auth, ITokenServices tokenService)
        {
            _config = config;
            _authenticationService = auth;
            _tokenService = tokenService;
        }


        [HttpPost]
        public async Task<IActionResult> Login([FromBody] AuthenticateRequestDTO login)
        {
            IActionResult response = Unauthorized();
            UserModel user =await _authenticationService.AuthenticateUser(login);

            if (user != null)
            {
                var tokenString = _tokenService.CreateToken(user);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = user,
                });
            }

            return response;
        }

    }
}
