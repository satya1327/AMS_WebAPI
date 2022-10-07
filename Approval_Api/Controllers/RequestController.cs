﻿using Approval_Api.DataModel_.entities;
using Approval_Api.Services.Interface;
using Approval_Api.Mapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Approval_Api.ServiceModel.DTO.Response;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.Services;
using Microsoft.AspNetCore.Authorization;

namespace Approval_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestController : ControllerBase
    {
        IMapper _mapper;
        private readonly IRequestServices _services;
        private readonly MailService _mailService;
        public RequestController(IRequestServices services,IMapper mapper, MailService mailService)
        {
            _services = services;
            _mapper = mapper;
            _mailService = mailService;
        }
       
        [HttpGet("GetAllRequestHistory")]
        public async Task<ActionResult<List<RequestDetailsDTO>>> GetAllRequestHistory()
        {
            var data = await _services.GetAllRequestHistory();
            if (data == null)
                return NotFound("No Data Found");
            else
            {
                var response = _mapper.Map<List<RequestDetailsDTO>>(data);
                return Ok(response);
            }
        }

       
        [HttpGet("GetAllRequest")]
        //[Authorize(Policy = UserRoles.Admin)]
        public async Task<ActionResult<List<RequestDetailsDTO>>> GetAllRequest()
        {
            var data = await _services.GetAllRequest();
            if (data == null)
                return NotFound("No Data Found");
            else
            {
                var response = _mapper.Map<List<RequestDetailsDTO>>(data);
                return Ok(response);
            }
        }
        [HttpGet("{id:int}")]
        public async Task<ActionResult<RequestDetailsDTO>> GetRequestById(int id)
        {
            var data = await _services.GetRequestById(id);
            if (data == null)
                return NotFound("please specify valid id");
            else
            {
               
                var response = _mapper.Map<RequestDetailsDTO>(data);
                return Ok(response);
            }
        }
        [HttpGet("GetRequestByUserId")]
        public  ActionResult<List<RequestDetailsDTO>> GetRequestByManagerId(int id)
        {
            var data =  _services.GetRequestByManagerId(id);
            if (data == null)
                return NotFound("please specify valid id");
            else
            {

                var response = _mapper.Map<List<RequestDetailsDTO>>(data);
                return Ok(response);
            }
        }
        [HttpPost("AddRequest")]
        public async Task<ActionResult<RequestDataDTO>>AddRequest(RequestDataDTO request)
        {
            

            var response = _mapper.Map<Request>(request);
            var requestNew = await _services.AddRequest(response);
           
            var requestDetails = _mapper.Map<RequestDataDTO>(response);

            if (requestDetails == null)
            {
                return BadRequest("please enter valid data");

            }
            else
            {
               
                return  Ok();
            }
        }

        [HttpDelete("DeleteRequest")]

        public async Task<ActionResult<Request>>DeleteRequest(int id)
        {
            var data = await _services.DeleteRequest(id);
            if (data == 0)
                return BadRequest("please enter valid id");
            else
                return Ok("successfully deleted");
        }

        [HttpPut("UpadteRequest")]

        public async Task<ActionResult<RequestDataDTO>>UpdateRequest(RequestDataDTO request,int id)
        {


            var response = _mapper.Map<Request>(request);
            var requestNew = await _services.UpdateRequest(response,id);
            var requestDetails = _mapper.Map<RequestDataDTO>(response);
            if (requestDetails == null)
            {
                return BadRequest("please enter valid data");
            }
            else
            {
                return Ok();
            }

        }

       
        //[HttpPut("RejectRequest")]

        //public async Task<ActionResult<int>> RejectRequest(RequestDataDTO request, int id)
        //{
        //    var data = _mapper.Map<Request>(request);
        //    var requestNew = _services.RejectRequest(data, id);
        //    var requestDetails = _mapper.Map<RequestDetailsDTO>(data);

        //    if (requestNew == null)
        //        return 0;
        //    else
        //        return 1;
        //}
        //[HttpPut("ApproveRequest")]

        //public async Task<ActionResult<int>> ApproveRequest(RequestDataDTO request, int id)
        //{
        //    var data = _mapper.Map<Request>(request);
        //    var requestNew = _services.ApprovedRequest(data, id);
        //    var requestDetails = _mapper.Map<RequestDetailsDTO>(data);

        //    if (requestNew == null)
        //        return 0;
        //    else
        //        return 1;
        //}



    }
}
