
using Approval_Api.DataModel.Repository.Interface;
using Approval_Api.DataModel_.entities;
using Approval_Api.helpers;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using MailKit;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;






namespace Approval_Api.DataModel.Repository
{
    public class RequestRepository : IRequestRepository
    {
        private readonly Approval_DatabaseContext _databaseContext;
         
        
        public RequestRepository(Approval_DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
           
        }

       
        public async Task<List<RequestDetailsDTO>> GetAllRequest()
        {
            var userList = (from u in _databaseContext.Employees
                            join r in _databaseContext.Requests on u.UserId equals r.UserId
                            join s in _databaseContext.Statuses on r.StatusId equals s.StatusId
                            join e in _databaseContext.Employees on u.ManagerId equals e.UserId

                            select new RequestDetailsDTO
                            {

                                ReqId = r.ReqId,
                                first_name = u.FirstName,
                                last_name = u.LastName,
                                Purpose = r.Purpose,
                                Description = r.Description,
                                AdvAmount = r.AdvAmount,
                                EstimatedAmount = r.EstimatedAmount,      
                                Date = r.Date,
                                statusName = s.StatusName,
                                Comments = r.Comments,
                                UserId = u.UserId,
                                ManagerId=r.ManagerId,
                                approverName=e.FirstName

                            }).ToListAsync();
            return await userList;
    }


        public async Task<List<RequestDetailsDTO>> GetAllRequestHistory()
        {
            var userList = (from u in _databaseContext.Employees
                            join r in _databaseContext.Requests on u.UserId equals r.UserId
                            join s in _databaseContext.Statuses on r.StatusId equals s.StatusId

                            select new RequestDetailsDTO
                            {

                                ReqId = r.ReqId,
                                Name = u.FirstName+" "+u.LastName,                          
                                Purpose = r.Purpose,
                                Description = r.Description,
                                AdvAmount = r.AdvAmount,
                                EstimatedAmount = r.EstimatedAmount,
                                Date = r.Date,
                                statusName = s.StatusName,
                                Comments = r.Comments,
                             
                            }).ToListAsync();
            return await userList;




        }
       
        public async Task<RequestDetailsDTO> GetRequestById(int id)
        {
            var userList =await  (from u in _databaseContext.Employees
                            join r in _databaseContext.Requests on u.UserId equals r.UserId
                            join s in _databaseContext.Statuses on r.StatusId equals s.StatusId
                            

                            select new RequestDetailsDTO
                            {

                                ReqId=r.ReqId,
                                Name=u.FirstName+" "+u.LastName,
                                Purpose = r.Purpose,
                                Description = r.Description,
                                AdvAmount = r.AdvAmount,
                                EstimatedAmount = r.EstimatedAmount,
                                Date = r.Date,
                                statusName = s.StatusName,
                                Comments = r.Comments,
                                UserId = u.UserId,
                              




                            }).ToListAsync();
            var data = userList.Where(x => x.ReqId == id).FirstOrDefault();
            return  data;
        }

        public async Task<List<RequestDetailsDTO>> GetRequestByManagerId(int id)
        {
            var userList =await  (from r in _databaseContext.Requests
                                  join e in _databaseContext.Employees on r.UserId equals e.UserId
                                 
                                  join s in _databaseContext.Statuses on r.StatusId equals s.StatusId




                                  select new RequestDetailsDTO
                                  {

                                      ReqId = r.ReqId,
                                      first_name = e.FirstName,
                                      last_name = e.LastName,
                                      Purpose = r.Purpose,
                                      Description = r.Description,
                                      AdvAmount = r.AdvAmount,
                                      EstimatedAmount = r.EstimatedAmount,
                                      Date = r.Date,
                                      statusName = s.StatusName,
                                      Comments = r.Comments,
                                      UserId = e.UserId,
                                      ManagerId = r.ManagerId
                                     



                                  }).ToListAsync();
           var data=userList.Where(x => x.ManagerId == id).Select(x=>x).ToList();
            return data;
        }
        public  async Task< int> AddRequest(Request request)
        {
            if (request == null)
            {
                return 0;
            }
            else
            {
                request.StatusId = 1;

                  _databaseContext.Requests.Add(request);
                var employeeEmail =  _databaseContext.Employees.Where(e => e.UserId == request.UserId).Select(s => s.Email).FirstOrDefault();
                var managerEmail =  _databaseContext.Employees.Where(m => m.UserId == request.ManagerId).Select(x => x.Email).FirstOrDefault();
                string sender = Convert.ToString(employeeEmail);
                string reciever = Convert.ToString(managerEmail);
                int Status = Convert.ToInt32(request.StatusId);

                 EmailServices.smtpMailer(Status, sender, reciever,"");


                await _databaseContext.SaveChangesAsync();
                return  1;
            }
        }

        public async Task<int> DeleteRequest(int id)
        {
            var data =await _databaseContext.Requests.FindAsync(id);
            if (data == null)
                return 0;
            else
                _databaseContext.Remove(data);
            _databaseContext.SaveChanges();
            return 1;
        }

        public async Task<int> UpdateRequest(Request request,int id)
        {
            try
            {
                var data =await _databaseContext.Requests.FindAsync(id);
                if (data!= null)
                {

                    if (request.StatusId == 3)
                    {

                        data.StatusId = 3;
                        data.Comments = request.Comments;
                        data.UserId = request.UserId;
                        var employeeEmail = _databaseContext.Employees.Where(e => e.UserId == request.UserId).Select(s => s.Email).FirstOrDefault();
                        var managerEmail = _databaseContext.Employees.Where(m => m.UserId == data.ManagerId).Select(x => x.Email).FirstOrDefault();
                        string sender = Convert.ToString(employeeEmail);
                        string reciever = Convert.ToString(managerEmail);
                        int status = Convert.ToInt32(request.StatusId);

                        data.UserId = request.UserId;
                        EmailServices.smtpMailer(status, reciever, sender, request.Comments);

                    }
                    else if (request.StatusId == 2)
                    {

                        data.StatusId = 2;
                        var employeeEmail = _databaseContext.Employees.Where(e => e.UserId == request.UserId).Select(s => s.Email).FirstOrDefault();
                        var managerEmail = _databaseContext.Employees.Where(m => m.UserId == data.ManagerId).Select(x => x.Email).FirstOrDefault();
                        string sender = Convert.ToString(employeeEmail);
                        string reciever = Convert.ToString(managerEmail);
                        int status = Convert.ToInt32(request.StatusId);

                        data.UserId = request.UserId;
                        EmailServices.smtpMailer(status, reciever, sender, "");
                    }
                    else if (request.StatusId == 1002)
                    {

                        data.StatusId = 1002;

                        data.UserId = request.UserId;
                       
                    }
                    else if (request.StatusId == 2002)
                    {

                        data.StatusId = 2002;
                        
                        var employeeEmail = _databaseContext.Employees.Where(e => e.UserId == data.UserId).Select(s => s.Email).FirstOrDefault();
                        var managerEmail = "sachinmittalkod@gmail.com";
                        string sender = Convert.ToString(employeeEmail);
                        string reciever = Convert.ToString(managerEmail);
                        int status = Convert.ToInt32(request.StatusId);

                        data.UserId = request.UserId;
                        data.ManagerId = 2;
                        EmailServices.smtpMailer(status,sender, reciever,   "");

                        data.UserId = request.UserId;

                    }


                    data.Purpose = request.Purpose;
                    data.Description = request.Description;
                    data.EstimatedAmount = request.EstimatedAmount;
                    data.AdvAmount = request.AdvAmount;
                    data.Date = request.Date;
                    
               
                    

                }
                _databaseContext.Entry(data).State = EntityState.Modified;
                _databaseContext.SaveChanges();
                return 1;
            }
            catch
            {
                throw;
            }

        }

      
        public async Task<List<RequestDataDTO>> GetTotalApprovedRequest()
        {

            var userList =await  (from u in _databaseContext.Employees
                            join r in _databaseContext.Requests on u.UserId equals r.UserId
                            join s in _databaseContext.Statuses on r.StatusId equals s.StatusId

                            select new RequestDataDTO
                            {

                                ReqId = r.ReqId,
                               
                                Purpose = r.Purpose,
                                Description = r.Description,
                                AdvAmount = r.AdvAmount,
                                EstimatedAmount = r.EstimatedAmount,
                                StatusId = r.StatusId,
                                Date = r.Date,
                                statusName = s.StatusName,
                                Comments = r.Comments,
                                UserId = u.UserId,




                            }).ToListAsync();

            var bystatus=userList.Where(s=>s.StatusId==2).Select(x=>x).ToList();
            
            return  bystatus;
           

        }
        public  async Task<List<RequestDataDTO>> GetTotalRejectedRequest()
        {
            var userList =await  (from u in _databaseContext.Employees
                            join r in _databaseContext.Requests on u.UserId equals r.UserId
                            join s in _databaseContext.Statuses on r.StatusId equals s.StatusId

                            select new RequestDataDTO
                            {

                                ReqId = r.ReqId,

                                Purpose = r.Purpose,
                                Description = r.Description,
                                AdvAmount = r.AdvAmount,
                                EstimatedAmount = r.EstimatedAmount,
                                StatusId=r.StatusId,
                                Date = r.Date,
                                statusName = s.StatusName,
                                Comments = r.Comments,
                                UserId = u.UserId,



                            }).ToListAsync();

            var bystatus = userList.Where(s => s.StatusId == 3).Select(x => x).ToList();
            return bystatus;
        }

        //public async Task<int> GetTotalRequest()
        //{
        //    var data =await  _databaseContext.Requests.Where(x => x.StatusId==1  ).CountAsync();
        //    return  data;
        //}
        //public async Task<int> GetApproveRequest()
        //{
        //    var data =await  _databaseContext.Requests.Where(x => x.StatusId == 2).CountAsync();
        //    return data;
        //}
        //public async Task<int> GetRejectRequest()
        //{
        //    var data =await  _databaseContext.Requests.Where(x => x.StatusId == 3).CountAsync();
        //    return data;
        //}

       
    }
}
