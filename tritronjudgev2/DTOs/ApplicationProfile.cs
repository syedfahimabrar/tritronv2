using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Models;

namespace tritronAPI.DTOs
{
    public class ApplicationProfile:Profile
    {
        public ApplicationProfile()
        {
            CreateMap<User, UserRegisterDTO>()
                .ReverseMap();
            CreateMap<User, AuthorDto>();
            CreateMap<Language, LanguageDTO>();
            CreateMap<Problem, ProblemDto>()
                .ForMember(dest => dest.Languages,opt => opt.MapFrom(src => src.ProblemLanguages.Select(a => a.Language)));
            CreateMap<ProblemCreateDto, Problem>()
                .ForMember(dest=>dest.ProblemLanguages,opt =>opt.MapFrom(src=>src.ProblemLanguages.Select(id => new ProblemLanguage(){LanguageId = id})));
            CreateMap<ProblemDto, Problem>();
            CreateMap<CreateContestDto, Contest>().ForMember(
                dest => dest.Problems , opt => opt.MapFrom(src => src.Problems.Select(id => new Problem(){Id = id})))
                .ForMember(dest => dest.StartTime,opt => opt.MapFrom(src => DateTime.Parse(src.StartTime)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => DateTime.Parse(src.EndTime)));
        }
    }
}
