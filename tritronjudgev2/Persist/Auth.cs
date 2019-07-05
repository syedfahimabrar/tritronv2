using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using tritronAPI.Data;
using tritronAPI.Model;
using System.Net;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using tritronAPI.DTOs;
using tritronAPI.Extensions;

namespace tritronAPI.Persist
{
    public class Auth:IAuth
    {
        private DataContext _context;
        private SignInManager<User> _signInManager;
        private UserManager<User> _userManager;
        private string propic = "https://i.imgur.com/JajsGwl.png";
        public Auth(DataContext context,UserManager<User> userManager,SignInManager<User> signInManager)
        {
            this._context = context;
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public async Task<IdentityResult> Register(User user, string password)
        {
            var result = await this._userManager.CreateAsync(user, password);
            if(result.Succeeded)
                await _userManager.AddToRoleAsync(user, "gen");
            return result;
        }
        public async Task<LoginResult> Login(UserLoginDTO userlogindto)
        {
            var user = await _userManager.FindByNameAsync(userlogindto.UserName.ToLower());
            if (user == null)
                user = await _userManager.FindByEmailAsync(userlogindto.UserName.ToLower());
            if(user != null && await _userManager.CheckPasswordAsync(user,userlogindto.PassWord))
            {
                //Get role assigned to the user
                var role = await _userManager.GetRolesAsync(user);
                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                            new Claim("UserID",user.Id.ToString()),
                            new Claim(ClaimTypes.Name,user.UserName.ToString()),
                            new Claim("profilepic",user.ProfilePicUrl == null?propic:user.ProfilePicUrl), 
                            new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Fahim123456789Fahim123456789Fahim123456789Fahim123456789Fahim123456789")), SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                var result = new LoginResult()
                {
                    Succeeded = true,
                    Token = token
                };
                return result;

            }else if (user == null)
            {
                return new LoginResult(){Succeeded = false,Error = "user does not exist"};
            }
            return new LoginResult(){Succeeded = false,Error = "Password does not match"};
        }

        public bool UserExist(string userName)
        {
            if(userName.Contains('@'))
                return _context.Users.Any(u => u.Email == userName);
            return  _context.Users.Any(u => u.UserName == userName);
        }
    }
}
