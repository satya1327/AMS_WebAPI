
using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.DataModel.Repository.Interface
{
    public interface IRequestRepository
{
        Task<List<RequestDetailsDTO>> GetAllRequest();
        Task<List<RequestDetailsDTO>> GetAllRequestHistory();
        Task<List<RequestDetailsDTO>> GetRequestByManagerId(int id); 
        Task<RequestDetailsDTO> GetRequestById(int id);
        Task<int> AddRequest(Request request);
      
        Task<int> DeleteRequest(int id);
        Task<int> UpdateRequest(Request request, int id);

        //Task<int> GetTotalRequest();
       Task<List<RequestDataDTO>> GetTotalApprovedRequest();
        Task<List<RequestDataDTO>> GetTotalRejectedRequest();
        //Task<int> GetApproveRequest();
        //Task<int> GetRejectRequest();

    }
}
