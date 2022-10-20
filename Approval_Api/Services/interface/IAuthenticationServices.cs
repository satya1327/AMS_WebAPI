using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using System.Threading.Tasks;

namespace Approval_Api.Services
{
    public interface IAuthenticationServices
    {
        Task<UserModel> AuthenticateUser(AuthenticateRequestDTO loginCredentials);
       
        Task<bool> CheckUserAvailabity(string userName);

        Task<bool> isUserExists(int userId);
    }
}
