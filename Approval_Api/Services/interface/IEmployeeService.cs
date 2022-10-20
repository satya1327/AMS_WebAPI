using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Approval_Api.Services
{
    public interface IEmployeeService
    {
        Task<List<UserViewModelDTO>> GetAllUsers();
        Task<UserViewModelDTO> GetUserById(int id);
        Task<int> AddUser(Employee emp);
        Task<int> UpdateUser(Employee emp, int id);
        Task<int> DeleteUser(int id);  
    }
}
