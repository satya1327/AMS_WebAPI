using Approval_Api.DataModel_.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.DataModel_.Repository
{
    public interface IAuthenticationRepository
    {

        Employee AuthenticateUser(Employee loginCredentials);
        int RegisterUser(Employee userData);
        bool CheckUserAvailabity(string userName);

        bool isUserExists(int userId);
    }
}
