using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using Approval_Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Approval_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationServices _authenticationService;
        IMapper _mapper;
        public AuthenticationController(IAuthenticationServices authenticationService,IMapper mapper)
        {
            _authenticationService = authenticationService;
            _mapper = mapper;
        }
        [HttpGet("CheckUserAvailability")]
        public async Task<ActionResult<bool>>CheckUserAvailability(string email)
        {
            return await _authenticationService.CheckUserAvailabity(email);
        }

        [HttpPost("AuthenticationUser")]

        public async Task< ActionResult<AuthenticateResponseDTO>> AuthenticateUser(AuthenticateRequestDTO emp)
        {
            var response = _mapper.Map<Employee>(emp);
            var requestNew = await _authenticationService.AuthenticateUser(response);

            var requestDetails =  _mapper.Map<AuthenticateResponseDTO>(requestNew);
            if (requestDetails != null)
            {
                return Ok(requestDetails);
            }
            else
            {
                return BadRequest("No data found");
            }
        }

        [HttpGet("IsuserExist")]

        public async Task<bool>IsUserExist(int UserId)
        {
            return await _authenticationService.isUserExists(UserId);
        }




    }
}
