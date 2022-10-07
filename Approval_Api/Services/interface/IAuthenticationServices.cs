using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using System.Threading.Tasks;

namespace Approval_Api.Services
{
    public interface IAuthenticationServices
    {
        UserRequestDTO AuthenticateUser(UserRequestDTO loginCredentials);
       
        Task<bool> CheckUserAvailabity(string userName);

        Task<bool> isUserExists(int userId);
    }
}
