using Approval_Api.DataModel_.entities;
using Approval_Api.DataModel_.Repository;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using System.Collections.Generic;

namespace Approval_Api.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _userRepository;
        public EmployeeService(IEmployeeRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public int AddUser(Employee emp)
        {
            return _userRepository.AddUser(emp);
        }

        public int DeleteUser(int id)
        {
            return _userRepository.DeleteUser(id);
        }

        public List<UserViewModelDTO> GetAllUsers()
        {
            return _userRepository.GetAllUsers();
        }

        public UserViewModelDTO GetUserById(int id)
        {
            return _userRepository.GetUserById(id);

        }

        public int UpdateUser(Employee emp, int id)
        {
            return _userRepository.UpdateUser(emp, id);
        }
    }
}
