using Approval_Api.DataModel_.entities;
using Approval_Api.DataModel_.Repository;
using System.Threading.Tasks;

namespace Approval_Api.Services
{
    public class AuthenticationServices : IAuthenticationServices
    {
        private readonly IAuthenticationRepository _authenticationRepository;
        public AuthenticationServices(IAuthenticationRepository authenticationRepository)
        {
            _authenticationRepository = authenticationRepository;
        }

        public async Task<Employee> AuthenticateUser(Employee loginCredentials)
        {
           return await _authenticationRepository.AuthenticateUser(loginCredentials);
        }

        public async Task< bool> CheckUserAvailabity(string userName)
        {
            return await _authenticationRepository.CheckUserAvailabity(userName);
        }

        public async Task<bool> isUserExists(int userId)
        {
            return await _authenticationRepository.isUserExists(userId);
        }

     
    }
}
