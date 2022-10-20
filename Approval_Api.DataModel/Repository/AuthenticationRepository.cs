using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.DataModel_.Repository
{
    public class AuthenticationRepository : IAuthenticationRepository
    {
        private readonly Approval_DatabaseContext _databaseContext;
        public AuthenticationRepository(Approval_DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<UserModel> AuthenticateUser(AuthenticateRequestDTO loginCredentials)
        {
            UserModel userMaster = new UserModel();
            var userDetails =await _databaseContext.Employees.FirstOrDefaultAsync(u => u.Email == loginCredentials.Email

            && u.Password == loginCredentials.Password);
            if (userDetails != null)
            {
                var user = new UserModel
                {
                    FirstName = userDetails.FirstName,
                    LastName= userDetails.LastName,
                    UserName = userDetails.UserName,
                    UserId = userDetails.UserId,
                    RoleId = userDetails.RoleId,
                   ManagerId=userDetails.ManagerId      
                };

                return user;
            }
            else
            {
                return null;
            }

           
        }


        public async Task<bool> CheckUserAvailabity(string email)
        {
            string user = _databaseContext.Employees.FirstOrDefault(x => x.Email == email)?.ToString();
            if (user != null)
            {
                return true;
            }
            else
                return false;
        }

        public async  Task<bool> isUserExists(int userId)
        {
            string user = _databaseContext.Employees.FirstOrDefault(x => x.UserId == userId)?.ToString();
            if (user != null)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

      
        
    }
}
