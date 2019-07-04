using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using tritronAPI.Model;

namespace tritronAPI.Persist
{
    public interface IAuth
    {
        Task<IdentityResult> Register(User user, string password);
        Task<User> Login(string userName, string password);
        bool UserExist(string userName);
    }
}
