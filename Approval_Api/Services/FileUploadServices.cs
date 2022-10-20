using Approval_Api.DataModel_.entities;
using Approval_Api.DataModel_.Repository;
using System.Threading.Tasks;

namespace Approval_Api.Services
{
    public class FileUploadServices:IFileUploadServices
    {
        private readonly IFileUploadRepository _fileUploadRepository;
        public FileUploadServices(IFileUploadRepository fileUploadRepository)
        {
            _fileUploadRepository = fileUploadRepository;
        }

        public async Task<int> FileUpload(Upload upload)
        {
            return await _fileUploadRepository.FileUploads(upload);
        }
    }
}
