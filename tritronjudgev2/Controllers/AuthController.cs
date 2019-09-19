using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Models;
using tritronAPI.DTOs;

namespace tritronAPI.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController:Controller
    {
        private IMapper _mapper;
        private IAuth _auth;

        public AuthController(IAuth auth,IMapper mapper)
        {
            this._auth = auth;
            this._mapper = mapper;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDTO user)
        {
            user.UserName = user.UserName.ToLower();
            //if (this._auth.UserExist(user.UserName))
            //    return BadRequest("User Already Exist");
            //if (this._auth.UserExist(user.Email))
            //    return BadRequest("Email Already Exist");
            var userToRegister = _mapper.Map<User>(user);
            var result = await this._auth.Register(userToRegister, user.PassWord);
            if(result.Succeeded)
                return Ok(result);
            return BadRequest(result);
        }
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(UserLoginDTO loginDto)
        {
            User user = new User(){UserName = loginDto.UserName};
            var result = await _auth.Login(user,loginDto.PassWord);
            if (result.Succeeded)
            {
                return Ok(result);
            }

            return BadRequest(error: result);
            
            //var user = await _userManager.FindByNameAsync(model.UserName);
            //if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            //{
            //    //Get role assigned to the user
            //    var role = await _userManager.GetRolesAsync(user);
            //    IdentityOptions _options = new IdentityOptions();

            //    var tokenDescriptor = new SecurityTokenDescriptor
            //    {
            //        Subject = new ClaimsIdentity(new Claim[]
            //        {
            //            new Claim("UserID",user.Id.ToString()),
            //            new Claim(_options.ClaimsIdentity.RoleClaimType,role.FirstOrDefault())
            //        }),
            //        Expires = DateTime.UtcNow.AddDays(1),
            //        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_appSettings.JWT_Secret)), SecurityAlgorithms.HmacSha256Signature)
            //    };
            //    var tokenHandler = new JwtSecurityTokenHandler();
            //    var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            //    var token = tokenHandler.WriteToken(securityToken);
            //    return Ok(new { token });
            //}
            //else
            //    return BadRequest(new { message = "Username or password is incorrect." });
            return null;
        }
    }
}
