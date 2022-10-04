using Approval_Api.DataModel_.entities;
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

        public async Task<Employee> AuthenticateUser(Employee loginCredentials)
        {
            Employee userMaster = new Employee();
            var userDetails = _databaseContext.Employees.FirstOrDefault(u => u.Email == loginCredentials.Email

            && u.Password == loginCredentials.Password);
            if (userDetails != null)
            {
                var emp = new Employee()
                {
                    UserName = userDetails.UserName,
                    UserId = userDetails.UserId,
                    RoleId = userDetails.RoleId
                };

                return emp;
            }

            else
            {
                return userDetails;
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
