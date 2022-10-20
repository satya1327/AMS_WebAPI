using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.ServiceModel.DTO.Request
{
    public class UploadFileDTO
    {
      
        public int? ReqId { get; set; }
        public string Comments { get; set; }
        public int? SpendAmount { get; set; }

        public IFormFile File { get; set; }

    }
}
