
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
        List<RequestDetailsDTO> GetRequestByManagerId(int id); 
        Task<RequestDetailsDTO> GetRequestById(int id);
        Task<int> AddRequest(Request request);
        Task<int> ActionRequest(Request request, int id);
        //public int ApprovedRequest(Request request, int id);
        Task<int> DeleteRequest(int id);
        Task<int> UpdateRequest(Request request, int id);

        int GetTotalRequest();
       List<RequestDataDTO> GetTotalApprovedRequest();
        List<RequestDataDTO> GetTotalRejectedRequest();
        int GetApproveRequest();
        int GetRejectRequest();

    }
}
