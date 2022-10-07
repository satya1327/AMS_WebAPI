using Approval_Api.DataModel_.entities;
using Approval_Api.DataModel_.Repository;

namespace Approval_Api.Services
{
    public class FileUploadServices:IFileUploadServices
    {
        private readonly IFileUploadRepository _fileUploadRepository;
        public FileUploadServices(IFileUploadRepository fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;
        }

        public int FileUploads(int id, Upload UploadObj)
        {
            return _fileUploadRepository.FileUploads(id, UploadObj);
        }
    }
}
