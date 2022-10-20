using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using Approval_Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Approval_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _userService;
        IMapper _mapper;

        public EmployeeController(IEmployeeService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [HttpGet("GetAllUser")]


      
        public async Task<ActionResult<List<UserViewModelDTO>>> GetAllUser()
        {
            var data =await _userService.GetAllUsers();
            if (data == null)
                return NotFound("No data found");
            else
                return Ok(data);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModelDTO>>GetUserById(int id)
        {
            var data=await _userService.GetUserById(id);
            if (data == null)
                return NotFound("please enter correct id");
            else
                return Ok(data);
        }
        [HttpPost("AddUser")]

        public async Task<ActionResult<UserRequestDTO>>AddUser(UserRequestDTO user)
        {
            var response = _mapper.Map<Employee>(user);
            var requestNew = await _userService.AddUser(response);

            var requestDetails = _mapper.Map<UserRequestDTO>(response);
            if (requestDetails == null)
                return BadRequest("insert data");
            else

            return Ok("user added successfully");
        }

        [HttpPatch("UpdateRequest")]
    
        public async Task<ActionResult<UserRequestDTO>>UpdateUser(UserRequestDTO emp,int id)
        {
            var response = _mapper.Map<Employee>(emp);
            var requestNew = await _userService.UpdateUser(response,id);

            var requestDetails = _mapper.Map<UserRequestDTO>(response);

            if (emp == null)
            {
                return BadRequest("no data found");
            }
            else
            {

                return Ok("update successfully");
            }
        }
        [HttpDelete("DeleteUser{id:int}")]
        public async Task<int>DeleteUser(int id)
        {
            var data= await _userService.DeleteUser(id);
            if (data == 0)
            {
                return 0;
            }
            else
            {

                return 1;
            }
            }




      


    }
}
