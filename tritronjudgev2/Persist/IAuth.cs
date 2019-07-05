using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using tritronAPI.DTOs;
using tritronAPI.Extensions;
using tritronAPI.Model;

namespace tritronAPI.Persist
{
    public interface IAuth
    {
        Task<IdentityResult> Register(User user, string password);
        Task<LoginResult> Login(UserLoginDTO userLoginDto);
        bool UserExist(string userName);
    }
}
