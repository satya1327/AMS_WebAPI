using Approval_Api.DataModel_.entities;
using Approval_Api.ServiceModel.DTO.Request;
using Approval_Api.ServiceModel.DTO.Response;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Utilities.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Approval_Api.DataModel_.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly Approval_DatabaseContext _approval_data;
        public EmployeeRepository(Approval_DatabaseContext approval_data)
        {
            _approval_data = approval_data;
        }

        public int AddUser(Employee emp)
        {

            if (emp == null)
                return 0;
            else
                emp.RoleId = 1;
            
             _approval_data.Employees.Add(emp);
            
            _approval_data.SaveChanges();
            return 1;
        }

        public int DeleteUser(int id)
        {
            var data = _approval_data.Employees.Find(id);
            if (data == null)
                return 0;
            else
                _approval_data.Employees.Remove(data);
                _approval_data.SaveChanges();
            return 1;

        }

        public List<UserViewModelDTO> GetAllUsers()
        {
            var userList = (from u in _approval_data.Employees
                            join r in _approval_data.Roles on u.RoleId equals r.RoleId
                           join us in _approval_data.Employees on u.UserId equals us.ManagerId
                          
                            select new UserViewModelDTO
                            {
                                UserId = us.UserId,
                                FirstName = us.FirstName,
                                LastName = us.LastName,
                                Email = u.Email,
                                roleName = r.RoleName,
                                UserName = u.UserName,
                                managerName=u.FirstName+" "+u.LastName
                               
                                
                            }).ToList();

            return userList;
        }

        public UserViewModelDTO GetUserById(int id)
        {
            var userList = (from u in _approval_data.Employees
                            join r in _approval_data.Roles on u.RoleId equals r.RoleId

                            select new UserViewModelDTO
                            {
                                UserId = u.UserId,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                                roleName = r.RoleName,
                                UserName = u.UserName,


                            }).ToList();

            var data = userList.Where(x => x.UserId == id).FirstOrDefault();
            return data;
        }
      
        public int UpdateUser(Employee emp, int id)
        {
            var data=_approval_data.Employees.Find(id);
            if (data == null)
                return 0;
            else
                data.UserName = emp.UserName;
                data.RoleId = emp.RoleId;
                data.FirstName = emp.FirstName;
                data.LastName = emp.LastName;
                data.Email = emp.Email;
                _approval_data.Entry(data).State = EntityState.Modified;
                _approval_data.SaveChanges();
            return 1;
        }

       
    }
}
