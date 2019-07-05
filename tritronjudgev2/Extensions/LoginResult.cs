using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tritronAPI.Extensions
{
    public class LoginResult
    {
        public bool Succeeded { get; set; }
        public string Token { get; set; }
        public string Error { get; set; }
    }
}
