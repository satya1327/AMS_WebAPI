

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

        public async Task<int> DeleteRequest(int id)
        {
           return await _requestRepository.DeleteRequest(id);
        }

        public async Task<List<RequestDetailsDTO>> GetAllRequest()
        {
            return await _requestRepository.GetAllRequest();
        }

        public async Task<RequestDetailsDTO> GetRequestById(int id)
        {
          return await _requestRepository.GetRequestById(id);
        }

        public   List<RequestDataDTO> GetTotalApprovedRequest()
        {
            return  _requestRepository.GetTotalApprovedRequest();
        }

        public  List<RequestDataDTO> GetTotalRejectedRequest()
        {
            return  _requestRepository.GetTotalRejectedRequest();
        }

        public int GetTotalRequest()
        {
            return  _requestRepository.GetTotalRequest();
        }

        public async Task<int> UpdateRequest(Request request, int id)
        {
           return await _requestRepository.UpdateRequest(request, id);
        }
        //public int RejectRequest(Request request, int id)
        //{
        //    return _requestRepository.ActionRequest(request, id);
        //}

        public async Task<int> ActionRequest(Request request, int id)
        {
            return await _requestRepository.ActionRequest(request, id);
        }

        public Task<List<RequestDetailsDTO>> GetAllRequestHistory()
        {
            return _requestRepository.GetAllRequestHistory();
        }

        public Task<List<RequestDetailsDTO>> GetRequestByUserId(int id)
        {
            return _requestRepository.GetRequestByUserId(id);
        }

        //public int ApprovedRequest(Request request,int id)
        //{
        //    return _requestRepository.ApprovedRequest(request, id);
        //}
    }
}
