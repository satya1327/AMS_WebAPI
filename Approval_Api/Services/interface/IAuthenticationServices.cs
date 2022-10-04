using Approval_Api.DataModel_.entities;
using System.Threading.Tasks;

namespace Approval_Api.Services
{
    public interface IAuthenticationServices
    {
       Task<Employee> AuthenticateUser(Employee loginCredentials);
       
        Task<bool> CheckUserAvailabity(string userName);

        Task<bool> isUserExists(int userId);
    }
}
