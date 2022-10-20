using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Approval_Api.DataModel_.entities
{
    public partial class Upload
    {
        public int UploadId { get; set; }
        public int? ReqId { get; set; }
        public string FileName { get; set; }
        public string Comments { get; set; }
        public int? SpendAmount { get; set; }
        [NotMapped]
        public IFormFile file { get; set; }
        public virtual Request Req { get; set; }
    }
}
