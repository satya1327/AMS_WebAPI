using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.ServiceModel.DTO.Request
{
    public  class AuthenticateRequestDTO
    {
        public string Email { get; set; }
       public string Password { get; set; }
    }
}
