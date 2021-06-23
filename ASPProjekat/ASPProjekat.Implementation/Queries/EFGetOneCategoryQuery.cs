using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Exceptions;
using ASPProjekat.Application.Queries;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ASPProjekat.Implementation.Queries
{
    public class EFGetOneCategoryQuery : IGetOneCategoryQuery
    {
        public int Id => 27;

        public string Name => "Get One Category";

        private readonly ASPProjekatContext context;
        private readonly IMapper mapper;

        public EFGetOneCategoryQuery(ASPProjekatContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public CategoryDto Execute(int search)
        {
            var category = context.Categories.FirstOrDefault(x => x.Id == search);
            if (category == null)
            {
                throw new EntityNotFoundException(search, typeof(Category));
            }
            var categoryDto = mapper.Map<CategoryDto>(category);
            return categoryDto;
        }
    }
}
