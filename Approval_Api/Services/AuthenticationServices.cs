using Approval_Api.DataModel_.entities;
using Approval_Api.DataModel_.Repository;

namespace Approval_Api.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationServices(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public Employee AuthenticateUser(Employee loginCredentials)
        {
           return _authenticationRepository.AuthenticateUser(loginCredentials);
        }

        public bool CheckUserAvailabity(string userName)
        {
            return _authenticationRepository.CheckUserAvailabity(userName);
        }

        public bool isUserExists(int userId)
        {
            return _authenticationRepository.isUserExists(userId);
        }

        public int RegisterUser(Employee userData)
        {
            return _authenticationRepository.RegisterUser(userData);
        }
    }
}
