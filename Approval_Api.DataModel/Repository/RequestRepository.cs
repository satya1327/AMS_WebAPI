
using Approval_Api.DataModel.Repository.Interface;
using Approval_Api.DataModel_.entities;
using Approval_Api.helpers;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using MailKit;
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
                                ManagerId=r.ManagerId
                    



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
                                first_name = u.FirstName,
                                last_name = u.LastName,
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
                                first_name=u.FirstName,
                                last_name=u.LastName,
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

        public async Task<List<RequestDetailsDTO>> GetRequestByUserId(int id)
        {
            var userList = await (from u in _databaseContext.Employees
                                  join r in _databaseContext.Requests on u.UserId equals r.UserId
                                  join s in _databaseContext.Statuses on r.StatusId equals s.StatusId


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
                                     



                                  }).Where(x => x.UserId == id).ToListAsync();
           
            return userList;
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

                 EmailServices.smtpMailer(Status, sender, reciever);


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
                   
                    if(request.StatusId == 3)
                    {
                        data.StatusId = 3;
                        data.Comments = request.Comments;
                    }
                        //   book.CoverFileName=oldbookData.CoverFileName;
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

        public async Task<int> ActionRequest(Request request, int id)
        {
            try
            {
                var data =await _databaseContext.Requests.FindAsync(id);
                var mailvalue =await _databaseContext.Requests.Where(x => x.ReqId == id).FirstOrDefaultAsync();

                if (data != null)
                {

                    if (request.StatusId == 3)
                    {
                      
                        data.StatusId = 3;
                        data.Comments = request.Comments;
                        data.UserId = request.UserId;
                      
                    }
                    else if (request.StatusId == 2)
                    {
                        
                        data.StatusId = 2;
                      
                        data.UserId = request.UserId;
                    }


                    //   book.CoverFileName=oldbookData.CoverFileName;
                    
                   
                    

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


        //public int ApprovedRequest(Request request, int id)
        //{
        //    try
        //    {
        //        var data = _databaseContext.Requests.Find(id);
        //        if (data != null)
        //        {

        //            if (request.StatusId == 2)
        //            {
        //                data.StatusId = 2;
                        
        //            }
        //            //   book.CoverFileName=oldbookData.CoverFileName;

        //            data.UserId = request.UserId;
                    

        //        }
        //        _databaseContext.Entry(data).State = EntityState.Modified;
        //        _databaseContext.SaveChanges();
        //        return 1;
        //    }
        //    catch
        //    {
        //        throw;
        //    }

        //}

        //public async Task<int> GetTotlRequest()
        //{
            
        //}

        public List<RequestDataDTO> GetTotalApprovedRequest()
        {

            var userList = (from u in _databaseContext.Employees
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




                            }).ToList();

            var bystatus=userList.Where(s=>s.StatusId==2).Select(x=>x).ToList();
            return  bystatus;
           

        }
        public  List<RequestDataDTO> GetTotalRejectedRequest()
        {
            var userList =  (from u in _databaseContext.Employees
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



                            }).ToList();

            var bystatus = userList.Where(s => s.StatusId == 3).Select(x => x).ToList();
            return bystatus;
        }

        public int GetTotalRequest()
        {
            var data = _databaseContext.Requests.Select(x => x.ReqId).Count();
            return  data;
        }

        
    }
}
