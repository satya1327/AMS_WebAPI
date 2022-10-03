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
        List<UserViewModelDTO> GetAllUsers();
        UserViewModelDTO GetUserById(int id);
        int AddUser(Employee emp);
        int UpdateUser(Employee emp,int id);
        int DeleteUser(int id);
    }
}
