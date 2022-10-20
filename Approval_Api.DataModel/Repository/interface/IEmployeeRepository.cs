using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.DataModel_.Repository
{
    public interface IEmployeeRepository
    {
        Task<List<UserViewModelDTO>> GetAllUsers();
        Task<UserViewModelDTO> GetUserById(int id);
        Task<int> AddUser(Employee emp);
        Task<int> UpdateUser(Employee emp,int id);
        Task<int> DeleteUser(int id);
    }
}
