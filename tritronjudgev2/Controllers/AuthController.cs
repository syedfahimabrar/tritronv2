using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using tritronAPI.DTOs;
using tritronAPI.Model;
using tritronAPI.Persist;

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
    }
}
