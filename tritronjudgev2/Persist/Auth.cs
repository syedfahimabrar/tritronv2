using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tritronAPI.Data;
using tritronAPI.Model;
using System.Net;
using Microsoft.AspNetCore.Identity;

namespace tritronAPI.Persist
{
    public class Auth:IAuth
    {
        private DataContext _context;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;

        public Auth(DataContext context,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public async Task<IdentityResult> Register(User user, string password)
        {
            var result = await this._userManager.CreateAsync(user, password);
            return result;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        public Task<User> Login(string userName, string password)
        {
            throw new NotImplementedException();
        }

        public bool UserExist(string userName)
        {
            if(userName.Contains('@'))
                return _context.Users.Any(u => u.Email == userName);
            return  _context.Users.Any(u => u.UserName == userName);
        }
    }
}
