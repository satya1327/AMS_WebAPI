using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.DataModel_.Repository
{
    public interface IAuthenticationRepository
    {

        UserRequestDTO AuthenticateUser(UserRequestDTO loginCredentials);
        Task<bool> CheckUserAvailabity(string userName);

        Task<bool> isUserExists(int userId);
    }
}
