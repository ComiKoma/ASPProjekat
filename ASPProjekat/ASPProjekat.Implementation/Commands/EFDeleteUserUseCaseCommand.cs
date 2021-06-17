using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Application.Exceptions;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFDeleteUserUseCaseCommand : IDeleteUserUseCase
    {
        private readonly ASPProjekatContext context;

        public EFDeleteUserUseCaseCommand(ASPProjekatContext context)
        {
            this.context = context;
        }

        public int Id => 20;

        public string Name => "Delete UserUseCase";


        public void Execute(int request)
        {
            var item = context.UserUseCase.Find(request);

            if (item != null)
            {
                item.IsDeleted = true;
                item.DeletedAt = DateTime.Now;
                context.SaveChanges();
            }
            else
            {
                throw new EntityNotFoundException(request, typeof(UserUseCase));
            }
        }
    }
}
