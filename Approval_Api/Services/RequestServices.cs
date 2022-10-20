

using Approval_Api.ServiceModel.DTO.Response;
using Approval_Api.DataModel.Repository.Interface;
using Approval_Api.DataModel_.entities;
using Approval_Api.Services.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using Approval_Api.ServiceModel.DTO.Request;

namespace Approval_Api.Services
{
    public class RequestServices : IRequestServices
    {
        private readonly IRequestRepository _requestRepository;
        
        public RequestServices(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task< int> AddRequest(Request request)
        {
            return await _requestRepository.AddRequest(request);
            
        }

       
        public async Task<List<RequestDetailsDTO>> GetAllRequest()
        {
            return await _requestRepository.GetAllRequest();
        }

        public async Task<RequestDetailsDTO> GetRequestById(int id)
        {
          return await _requestRepository.GetRequestById(id);
        }

        public  async  Task<List<RequestDataDTO>> GetTotalApprovedRequest()
        {
            return  await _requestRepository.GetTotalApprovedRequest();
        }

        public  async Task<List<RequestDataDTO>> GetTotalRejectedRequest()
        {
            return await _requestRepository.GetTotalRejectedRequest();
        }

        //public async Task<int> GetTotalRequest()
        //{
        //    return  await _requestRepository.GetTotalRequest();
        //}

        public async Task<int> UpdateRequest(Request request, int id)
        {
           return await _requestRepository.UpdateRequest(request, id);
        }
      
        public async  Task<List<RequestDetailsDTO>> GetAllRequestHistory()
        {
            return await _requestRepository.GetAllRequestHistory();
        }

        public async Task<List<RequestDetailsDTO>> GetRequestByManagerId(int id)
        {
            return await _requestRepository.GetRequestByManagerId(id);
        }

        //public async Task<int> GetApproveRequest()
        //{
        //    return await _requestRepository.GetApproveRequest();
        //}

        //public async Task<int> GetRejectRequest()
        //{
        //    return await _requestRepository.GetRejectRequest();
        //}

        public async Task<int> DeleteRequest(int id)
        {
            return  await _requestRepository.DeleteRequest(id);
        }

       
    }
}
