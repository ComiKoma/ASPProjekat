using ASPProjekat.Application.Commands;
using ASPProjekat.Application.Exceptions;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFDeleteCategoryCommand : IDeleteCategory
    {
        private readonly ASPProjekatContext context;

        public EFDeleteCategoryCommand(ASPProjekatContext context)
        {
            this.context = context;
        }

        public int Id => 10;

        public string Name => "Delete Category Command";

        public void Execute(int request)
        {
            var cat = context.Categories.Find(request);

            if (cat == null)
            {
                throw new EntityNotFoundException(request, typeof(Category));
            }

            cat.IsDeleted = true;
            context.SaveChanges();
        }
    }
}
