using Approval_Api.DataModel_.entities;
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
using System.Runtime.InteropServices;

namespace Approval_Api.Controllers
{
    public class RequestStatusController:ControllerBase
    {
        IMapper _mapper;
        private readonly IRequestServices _services;
        private readonly MailService _mailService;
        public RequestStatusController(IRequestServices services, IMapper mapper,MailService mailService)
        {
            _services = services;
            _mapper = mapper;
            _mailService = mailService;
        }
        //[HttpGet("TotalRequest")]
        //public async Task<ActionResult<int>> GetTotalRequest()
        //{
        //    var data =await _services.GetTotalRequest();
        //    if (data == 0)
        //    {
        //        return BadRequest("No record found");
        //    }
        //    return Ok(data);
        //}
        //[HttpGet("ApprovedRquestCount")]
        //public async Task<ActionResult<int>> ApproveRequestCount()
        //{
        //    var data =await _services.GetApproveRequest();
        //    if (data == 0)
        //    {
        //        return BadRequest("No record found");
        //    }
        //    return Ok(data);
        //}
        //[HttpGet("RejectedRquestCount")]
        //public async Task<ActionResult<int>> RejectRequestCount()
        //{
        //    var data =await _services.GetRejectRequest();
        //    if (data == 0)
        //    {
        //        return BadRequest("No record found");
        //    }
        //    return Ok(data);
        //}


        [HttpGet("TotalApprovedRequest")]
        public async Task<ActionResult<List<RequestDataDTO>>> GetTotalApprovedRequest()
        {
            var data = await _services.GetTotalApprovedRequest();
            if (data == null)
                return BadRequest("no approved request found");
            else
            {
                var response = _mapper.Map<List<RequestDataDTO>>(data);
                return Ok(response);
            }
        }


        [HttpGet("TotalRejectedRequest")]
        public async Task<ActionResult<List<RequestDataDTO>>> GetTotalRejectedRequest()
        {
            var data =await  _services.GetTotalRejectedRequest();
            if (data == null)
                return BadRequest("no approved request found");

            else
            {
                var response = _mapper.Map<List<RequestDataDTO>>(data);
                return Ok(response);
            }
        }
     



    }
}
