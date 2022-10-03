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
        [HttpGet("TotalRequest")]
        public async Task<ActionResult<int>> GetTotalRequest()
        {
            var data = _services.GetTotalRequest();
            if (data == null)
            {
                return BadRequest("No record found");
            }
            return Ok($"Total record is {data}");
        }

        [HttpGet("TotalApprovedRequest")]
        public async Task<ActionResult<List<RequestDataDTO>>> GetTotalApprovedRequest()
        {
            var data =  _services.GetTotalApprovedRequest();
            if (data == null)
                return BadRequest("no approved request found");
            else
            {
                var response = _mapper.Map<List<RequestDataDTO>>(data);
                return Ok(response);
            }
        }

        [HttpGet("TotalRejectedRequest")]
        public ActionResult<List<RequestDataDTO>> GetTotalRejectedRequest()
        {
            var data =  _services.GetTotalRejectedRequest();
            if (data == null)
                return BadRequest("no approved request found");

            else
            {
                var response = _mapper.Map<List<RequestDataDTO>>(data);
                return Ok(response);
            }
        }
        [HttpPut("ActionRequest")]

        public async Task<ActionResult<int>> ActionRequest(RequestDataDTO request, int id)
        {
           
            var data = _mapper.Map<Request>(request);
            var requestNew = _services.ActionRequest(data, id);
            
            //var requestDetails = _mapper.Map<RequestDetailsDTO>(data);
            if(data.StatusId==2)
            {
               
                data.UserId = request.UserId;
               

            }
            else if(data.StatusId==3)
            {
              
             
            }
            if (requestNew != null)
                return 1;
            else
                return 0;
        }



    }
}
