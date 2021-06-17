using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
using ASPProjekat.Application.DataTransfer;
using ASPProjekat.Domain;
using ASPProjekat.EFDataAccess;
using ASPProjekat.Implementation.Validators;
using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ASPProjekat.Implementation.Commands
{
    public class EFCreateUserUseCaseCommand : ICreateUserUseCase
    {
        private readonly ASPProjekatContext context;
        private readonly CreateUserUseCaseValidator validator;
        private readonly IMapper mapper;
        private readonly IApplicationActor actor;

        public EFCreateUserUseCaseCommand(ASPProjekatContext context, CreateUserUseCaseValidator validator, IMapper mapper, IApplicationActor actor)
        {
            this.context = context;
            this.validator = validator;
            this.mapper = mapper;
            this.actor = actor;
        }


        public int Id => 19;

        public string Name => "Create UserUseCase";

        public void Execute(CreateUserUseCaseDto request)
        {
            validator.ValidateAndThrow(request);

            var userUseCaseMapped = mapper.Map<UserUseCase>(request);

            context.UserUseCase.Add(userUseCaseMapped);
            context.SaveChanges();
        }
    }
}
