using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Profiles
{
    public class ArticleProfile : Profile
    {
        public ArticleProfile()
        {
            CreateMap<Article, ArticleDto>()
            .ForMember(dto => dto.Name, opt => opt.MapFrom(a => a.Name))
            .ForMember(dto => dto.OnSale, opt => opt.MapFrom(a => a.OnSale))
            .ForMember(dto => dto.OldPrice, opt => opt.MapFrom(a => (a.OnSale == true) ? (a.Price.NewPrice) : (a.Price.OldPrice)))
            .ForMember(dto => dto.NewPrice, opt => opt.MapFrom(a => (a.OnSale == true) ? (a.Price.NewPrice) : 0))
            .ForMember(dto => dto.Id, opt => opt.MapFrom(a => a.Id))
            .ForMember(dto => dto.OnStock, opt => opt.MapFrom(a => a.OnStock))
            .ForMember(dto => dto.Picture, opt => opt.MapFrom(a => a.Picture));

            CreateMap<CreateArticleDto, Article>()
                .ForMember(a => a.Name, opt => opt.MapFrom(ca => ca.Name))
                .ForMember(a => a.OnSale, opt => opt.MapFrom(ca => ca.OnSale))
                //.ForMember(a => a.Price, opt => opt.MapFrom(ca => ca.OldPrice))
                //.ForMember(a => a.Price.NewPrice, opt => opt.MapFrom(ca => ca.NewPrice))
                .ForMember(a => a.Picture, opt => opt.MapFrom(ca => ca.Picture))
                //.ForMember(a => a.OldPrice, opt => opt.MapFrom(a => (a.OnSale == true) ? (a.Price.NewPrice) : (a.Price.OldPrice)))
                //.ForMember(dto => dto.NewPrice, opt => opt.MapFrom(a => (a.OnSale == true) ? (a.Price.NewPrice) : 0))
                .ForMember(a => a.OnStock, opt => opt.MapFrom(ca => ca.OnStock))
                .ForMember(a => a.Price, opt => opt.MapFrom(ca => ca));
            CreateMap<CreateArticleDto, Price>()
                .ForMember(a => a.NewPrice, opt => opt.MapFrom(dto => dto.NewPrice))
                .ForMember(a => a.OldPrice, opt => opt.MapFrom(dto => dto.OldPrice));
        }
    }
}
