using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Profiles
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<OrderDto, Order>()
            .ForMember(o => o.OrderDate, opt => opt.MapFrom(dto => dto.OrderDate))
            .ForMember(o => o.Address, opt => opt.MapFrom(dto => dto.Address))
            .ForMember(o => o.UserId, opt => opt.MapFrom(dto => dto.UserId))
            .ForMember(o => o.OrderLines, opt => opt.MapFrom(dto => dto.OrderLines.Select(c => new OrderLine
            {
                Price = (c.Article.OnSale) ? (c.Article.Price.NewPrice) : (c.Article.Price.OldPrice),
                Quantity = c.Quantity,
                Name = c.Article.Name,
                ArticleId = c.Article.Id
            })));

            CreateMap<Order, ReadOrderDto>()
           .ForMember(ro => ro.OrderDate, opt => opt.MapFrom(o => o.OrderDate))
           .ForMember(ro => ro.Address, opt => opt.MapFrom(o => o.Address))
           .ForMember(o => o.UserIdentity, opt => opt.MapFrom(dto => dto.User.Username))
           .ForMember(o => o.ReadOrderLines, opt => opt.MapFrom(dto => dto.OrderLines.Select(ol => new ReadOrderLineDto
           {
               Id = ol.Id,
               Price = (ol.Article.OnSale) ? (ol.Article.Price.NewPrice) : (ol.Article.Price.OldPrice),
               Quantity = ol.Quantity,
               ArticleName = ol.Article.Name,
           })));
        }
    }
}
