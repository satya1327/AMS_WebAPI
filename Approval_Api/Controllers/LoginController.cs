using Approval_Api.DataModel_.entities;
using Approval_Api.DataModel_.Repository;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using Approval_Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Approval_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationServices;
        private readonly IConfiguration config;
        private readonly ITokenServices _tokenServices;
        IMapper _mapper;
        public LoginController(IAuthenticationServices authenticationServices, IConfiguration config, ITokenServices tokenServices,IMapper mapper)
        {
            _authenticationServices = authenticationServices;
            this.config = config;
            _tokenServices = tokenServices;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult Login([FromBody] AuthenticateRequestDTO login)
        {
            IActionResult response = Unauthorized();
            var responses = _mapper.Map<Employee>(login);
            var requestNew =  _authenticationServices.AuthenticateUser(responses);

            var requestDetails = _mapper.Map<AuthenticateResponseDTO>(responses);

            if (responses != null)
            {
                var tokenString = _tokenServices.CreateToken(responses);
                response = Ok(new
                {
                    token = tokenString,
                    userDetails = requestDetails,
                });
            }

            return response;
        }
    }
}
