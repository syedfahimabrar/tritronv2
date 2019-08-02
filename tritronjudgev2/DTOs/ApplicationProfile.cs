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
            CreateMap<ProblemCreateDto, Problem>().ReverseMap();
            CreateMap<ProblemDto, Problem>();
            CreateMap<CreateContestDto, Contest>().ForMember(
                dest => dest.Problems , opt => opt.MapFrom(src => src.Problems.Select(id => new Problem(){Id = id})))
                .ForMember(dest => dest.StartTime,opt => opt.MapFrom(src => DateTime.Parse(src.StartTime)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => DateTime.Parse(src.EndTime)));
        }
    }
}
