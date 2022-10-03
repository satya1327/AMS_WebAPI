using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using System.Collections.Generic;

namespace Approval_Api.Services
{
    public interface IEmployeeService
    {
        List<UserViewModelDTO> GetAllUsers();
        UserViewModelDTO GetUserById(int id);
        int AddUser(Employee emp);
        int UpdateUser(Employee emp, int id);
        int DeleteUser(int id);  
    }
}
