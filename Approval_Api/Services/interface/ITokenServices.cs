using Approval_Api.DataModel_.entities;
using System.Threading.Tasks;

namespace Approval_Api.Services
{
  public interface ITokenServices
{
   string CreateToken(UserModel userInfo);
}
}
