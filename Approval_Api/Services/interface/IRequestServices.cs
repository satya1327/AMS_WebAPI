﻿using Approval_Api.ServiceModel.DTO.Response;
using Approval_Api.DataModel_.entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Approval_Api.ServiceModel.DTO.Request;

namespace Approval_Api.Services.Interface
{
    public interface IRequestServices
{
        Task<List<RequestDetailsDTO>> GetAllRequest();
        Task<List<RequestDetailsDTO>> GetAllRequestHistory();
        List<RequestDetailsDTO> GetRequestByManagerId(int id);
        Task<RequestDetailsDTO> GetRequestById(int id);
       Task<int> AddRequest(Request request);
       Task<int> ActionRequest(Request request, int id);
        //public int ApprovedRequest(Request request, int id);
        Task<int> DeleteRequest(int id);
        Task<int> UpdateRequest(Request request,int id);

        int GetTotalRequest();
        int GetApproveRequest();
        int GetRejectRequest();
        List<RequestDataDTO> GetTotalApprovedRequest();
       List<RequestDataDTO> GetTotalRejectedRequest();
    }
}
