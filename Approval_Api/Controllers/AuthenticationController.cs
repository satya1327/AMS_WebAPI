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

        [HttpGet("IsuserExist")]

        public async Task<bool>IsUserExist(int UserId)
        {
            return await _authenticationService.isUserExists(UserId);
        }




    }
}
