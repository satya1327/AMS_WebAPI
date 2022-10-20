using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.Services;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Approval_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadServices _FileUploadServices;
        private readonly IMapper _mapper;
        public FileUploadController(IFileUploadServices fileUploadServices,IMapper mapper)
        {
            _FileUploadServices = fileUploadServices;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task <ActionResult<int>> FileUpload([FromForm] UploadFileDTO upload)
        {
            var response=_mapper.Map<Upload>(upload);
            var NewResponse =await  _FileUploadServices.FileUpload(response);
            var requestDetails = _mapper.Map<UploadFileDTO>(response);
            if (requestDetails == null)
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
