using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using tritronAPI.Model;

namespace tritronAPI.DTOs
{
    public class ApplicationProfile:Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserRegisterDTO>()
                .ReverseMap();
        }
    }
}
