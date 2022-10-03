using Approval_Api.DataModel_.entities;

namespace Approval_Api.Services
{
    public interface IAuthenticationServices
    {
        Employee AuthenticateUser(Employee loginCredentials);
        int RegisterUser(Employee userData);
        bool CheckUserAvailabity(string userName);

        bool isUserExists(int userId);
    }
}
