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

        public async Task<int>AddUser(Employee emp)
        {

            if (emp == null)
            {
                return 0;
            }
            else
            {
                 _approval_data.Employees.Add(emp);
                await _approval_data.SaveChangesAsync();
                return  1;
            }
        }

        public async Task<int> DeleteUser(int id)
        {
            var data =await  _approval_data.Employees.FindAsync(id);
            if (data == null)
                return 0;
            else
                _approval_data.Employees.Remove(data);
                await _approval_data.SaveChangesAsync();
            return 1;

        }

        public async Task<List<UserViewModelDTO>> GetAllUsers()
        {
            var userList =await (from u in _approval_data.Employees
                            join r in _approval_data.Roles on u.RoleId equals r.RoleId
                            select new UserViewModelDTO
                            {
                                UserId = u.UserId,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                                roleId =r.RoleId,
                                UserName = u.UserName
                            }).ToListAsync();

            return userList;
        }

        public async Task<UserViewModelDTO> GetUserById(int id)
        {
            var userList =await  (from u in _approval_data.Employees
                            join r in _approval_data.Roles on u.RoleId equals r.RoleId
                            select new UserViewModelDTO
                            {
                                UserId = u.UserId,
                                FirstName =u.FirstName,
                                LastName = u.LastName,
                                Email = u.Email,
                                roleId = r.RoleId,
                                UserName = u.UserName,
                            }).ToListAsync();

            var data = userList.Where(x => x.UserId == id).FirstOrDefault();
            return data;
        }
      
        public async Task<int> UpdateUser(Employee emp, int id)
        {
            var data=await _approval_data.Employees.FindAsync(id);
            if (data == null)
                return 0;
            else
                data.UserName = emp.UserName;
                emp.RoleId = data.RoleId;
                data.FirstName = emp.FirstName;
                data.LastName = emp.LastName;
                emp.Email = data.Email;
                data.Password = emp.Password;
                _approval_data.Entry(data).State = EntityState.Modified;
               await  _approval_data.SaveChangesAsync();
            return 1;
        }

       
    }
}
