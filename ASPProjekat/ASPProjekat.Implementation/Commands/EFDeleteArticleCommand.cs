using ASPProjekat.Application.Commands;
using ASPProjekat.Application.Exceptions;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFDeleteArticleCommand : IDeleteArticleCommand
    {
        private readonly ASPProjekatContext context;

        public EFDeleteArticleCommand(ASPProjekatContext context)
        {
            this.context = context;
        }

        public int Id => 5;

        public string Name => "Delete Article Command";

        public void Execute(int request)
        {
            var item = context.Articles.Find(request);

            if (item != null)
            {
                // context.Articles.Remove(item);
                item.IsDeleted = true;
                item.DeletedAt = DateTime.Now;
                context.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException(request, typeof(Article));
            }
        }
    }
}
