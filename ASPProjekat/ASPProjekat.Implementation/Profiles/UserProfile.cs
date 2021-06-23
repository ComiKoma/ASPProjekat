using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekat.ApiApp.Core.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<RegisterUserDto, User>();

            CreateMap<User, UserDto>()
                .ForMember(dto => dto.Username, opt => opt.MapFrom(a => a.Username))
                .ForMember(dto => dto.LastName, opt => opt.MapFrom(a => a.LastName))
                .ForMember(dto => dto.FirstName, opt => opt.MapFrom(a => a.FirstName))
                .ForMember(dto => dto.Email, opt => opt.MapFrom(a => a.Email))
                .ForMember(dto => dto.IsAdmin, opt => opt.MapFrom(a => a.IsAdmin));

        }

    }
}
