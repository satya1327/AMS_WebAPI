using Approval_Api.DataModel_.entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.DataModel_.Repository
{
    public class FileUploadRepository : IFileUploadRepository
    {
        private readonly Approval_DatabaseContext _databaseContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public FileUploadRepository(Approval_DatabaseContext databaseContext,IWebHostEnvironment webHostEnvironment)
        {
            _databaseContext = databaseContext;
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost]
        public int FileUploads(int id, Upload UploadObj)
        {

            try
            {
                if (UploadObj.file.Length > 0)
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\UploadFile\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\UploadFile\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment.WebRootPath + "\\UploadFile\\" + UploadObj.file.FileName))
                    {
                        UploadObj.file.CopyTo(fileStream);
                        fileStream.Flush();

                        Upload upl = new Upload()
                        {

                            FileName = UploadObj.file.FileName,
                            ReqId = id,
                        };
                        _databaseContext.Uploads.Add(upl);
                        _databaseContext.SaveChanges();
                        return 1;
                    }

                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                return 0;
            }



        }


    }
}
