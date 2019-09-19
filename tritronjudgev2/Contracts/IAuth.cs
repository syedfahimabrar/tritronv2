using System.Threading.Tasks;
using Extension;
using Microsoft.AspNetCore.Identity;
using Models;

namespace Contracts
{
    public interface IAuth
    {
        Task<IdentityResult> Register(User user, string password);
        Task<LoginResult> Login(User userlogindto, string password);
        bool UserExist(string userName);
    }
}
