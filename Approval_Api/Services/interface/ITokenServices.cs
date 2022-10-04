using Approval_Api.DataModel_.entities;

namespace Approval_Api.Services
{
    public interface ITokenServices
{
        string CreateToken(Employee userInfo);
    }
}
