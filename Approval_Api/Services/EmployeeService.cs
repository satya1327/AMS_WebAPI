using Approval_Api.DataModel_.entities;
using Approval_Api.DataModel_.Repository;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Approval_Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _userRepository;
        public EmployeeService(IEmployeeRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<int> AddUser(Employee emp)
        {
            return await _userRepository.AddUser(emp);
        }

        public async Task<int> DeleteUser(int id)
        {
            return await _userRepository.DeleteUser(id);
        }

        public async Task<List<UserViewModelDTO>> GetAllUsers()
        {
            return await _userRepository.GetAllUsers();
        }

        public async  Task<UserViewModelDTO> GetUserById(int id)
        {
            return await _userRepository.GetUserById(id);

        }

        public async  Task<int> UpdateUser(Employee emp, int id)
        {
            return await _userRepository.UpdateUser(emp, id);
        }
    }
}
