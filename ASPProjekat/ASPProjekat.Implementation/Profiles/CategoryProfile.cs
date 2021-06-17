using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Searches;
using ASPProjekat.Domain;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPProjekat.Implementation.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<CategoryDto, Category>(); ;
        }
    }
}
