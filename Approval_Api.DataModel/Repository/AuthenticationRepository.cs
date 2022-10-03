using Approval_Api.DataModel_.entities;
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

        public Employee AuthenticateUser(Employee loginCredentials)
        {
            Employee userMaster = new Employee();
            var userDetails = _databaseContext.Employees.FirstOrDefault(u => u.UserName == loginCredentials.UserName

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

        public bool CheckUserAvailabity(string userName)
        {
            string user = _databaseContext.Employees.FirstOrDefault(x => x.UserName == userName)?.ToString();
            if (user != null)
            {
                return true;
            }
            else
                return false;
        }

        public bool isUserExists(int userId)
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

        public int RegisterUser(Employee userData)
        {
            try
            {
                userData.RoleId = 1;
                _databaseContext.Employees.Add(userData);
                _databaseContext.SaveChanges();
                return 1;
            }

            catch
            {
                throw;
            }
        }

        
    }
}
