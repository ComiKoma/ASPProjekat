using ASPProjekat.Application;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Profiles
{
    public class CartProfile : Profile
    {
        public CartProfile()
        {
            CreateMap<CartDto, Cart>()
             .ForMember(c => c.ArticleId, opt => opt.MapFrom(dto => dto.ArticleId))
             .ForMember(c => c.Quantity, opt => opt.MapFrom(dto => dto.Quantity));
        }
    }
}
