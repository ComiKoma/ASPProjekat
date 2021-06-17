using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Profiles
{
    public class CartLineProfile : Profile
    {
        public CartLineProfile()
        {
            CreateMap<Cart, CartLineDto>()
                .ForMember(dto => dto.Price, opt => opt.MapFrom(c => (c.Article.OnSale ? c.Article.Price.NewPrice : c.Article.Price.OldPrice)))
                .ForMember(dto => dto.Quantity, opt => opt.MapFrom(c => c.Quantity))
                .ForMember(dto => dto.ArticleName, opt => opt.MapFrom(c => c.Article.Name))
                .ForMember(dto => dto.Picture, opt => opt.MapFrom(c => c.Article.Picture));

            CreateMap<Cart, OrderLine>()
               .ForMember(ol => ol.Price, opt => opt.MapFrom(c => (c.Article.OnSale ? c.Article.Price.NewPrice : c.Article.Price.OldPrice)))
               .ForMember(ol => ol.Quantity, opt => opt.MapFrom(c => c.Quantity))
               .ForMember(ol => ol.Name, opt => opt.MapFrom(c => c.Article.Name))
               .ForMember(ol => ol.ArticleId, opt => opt.MapFrom(c => c.Article.Id));
        }
    }
}
