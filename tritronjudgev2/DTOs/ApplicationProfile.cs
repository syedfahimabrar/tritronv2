using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
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
                dest => dest.ContestProblems , opt => opt.MapFrom(src => src.Problems.Select(id => new ContestProblem(){ProblemId = id})))
                .AfterMap((dest, opt) =>
                {
                    int i = 0;
                    foreach (var num in dest.ProblemNumbers)
                    {
                        opt.ContestProblems.ElementAt(i).ProblemNumber= num;
                        i++;
                    }
                })
                .ForMember(dest => dest.StartTime,opt => opt.MapFrom(src => DateTime.Parse(src.StartTime)))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => DateTime.Parse(src.EndTime)));
        }
    }
}
