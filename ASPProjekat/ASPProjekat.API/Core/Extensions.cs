using ASPProjekat.ApiApp.Core.Profiles;
using ASPProjekat.Application;
using ASPProjekat.Application.Commands;
using ASPProjekat.Application.Email;
using ASPProjekat.Application.Queries;
using ASPProjekat.EFDataAccess;
using ASPProjekat.Implementation.Commands;
using ASPProjekat.Implementation.Email;
using ASPProjekat.Implementation.Logging;
using ASPProjekat.Implementation.Queries;
using ASPProjekat.Implementation.Validators;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ASPProjekat.API.Core
{
    public static class ApiExtensions
    {
        public static void AddDependencies(this IServiceCollection services)
        {

            services.AddTransient<UseCaseExecutor>();
            services.AddTransient<IFakerData, EFFakerData>();
            services.AddTransient<IEmailSender, SmtpEmailSender>();
            services.AddTransient<IUseCaseLogger, DatabaseUseCaseLogger>();
            services.AddTransient<ASPProjekatContext>();
            services.AddAutoMapper(typeof(UserProfile).Assembly);
            services.AddTransient<JwtManager>();
            services.AddControllers();
        }

        public static void AddSwaggerToProject(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ProjectForum", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
                      Enter 'Bearer' [space] and then your token in the text input below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                    {
                        {
                            new OpenApiSecurityScheme
                            {
                                Reference = new OpenApiReference
                                {
                                    Type = ReferenceType.SecurityScheme,
                                    Id = "Bearer"
                                },
                                Scheme = "oauth2",
                                Name = "Bearer",
                                In = ParameterLocation.Header,

                            },
                            new List<string>()
                        }
                    });
            }
            );
        }

        public static void AddApplicationActor(this IServiceCollection services)
        {
            services.AddHttpContextAccessor();
            services.AddTransient<IApplicationActor>(x =>
            {
                var accessor = x.GetService<IHttpContextAccessor>();

                var user = accessor.HttpContext.User;

                if (user.FindFirst("ActorData") == null)
                {
                    return new AnonymousActor();
                    //throw new InvalidOperationException("Actor data doesn't exist in token.");
                }

                var actorString = user.FindFirst("ActorData").Value;

                var actor = JsonConvert.DeserializeObject<JwtActor>(actorString);

                return actor;

            });
        }

        public static void AddJwt(this IServiceCollection services)
        {
            services.AddTransient<JwtManager>();
            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(cfg =>
            {
                cfg.RequireHttpsMetadata = false;
                cfg.SaveToken = true;
                cfg.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidIssuer = "asp_api",
                    ValidateIssuer = true,
                    ValidAudience = "Any",
                    ValidateAudience = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsMyVerySecretKey")),
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        public static void AddAllValidators(this IServiceCollection services)
        {
            services.AddTransient<CreateOrderValidator>();
            services.AddTransient<UpdateQuantityCartValidator>();
            services.AddTransient<InsertIntoCartValidator>();
            services.AddTransient<UpdateCategoryValidator>();
            services.AddTransient<UpdateArticleValidator>();
            services.AddTransient<CreateArticleValidator>();
            services.AddTransient<CreateCategoryValidator>();
            services.AddTransient<RegisterUserValidator>();
            services.AddTransient<UpdateUserValidator>();
        }

        public static void AddAllCommands(this IServiceCollection services)
        {
            services.AddTransient<ICreateArticleCommand, EFCreateArticleCommand>();
            services.AddTransient<ICreateCategoryCommand, EFCreateCategoryCommand>();
            services.AddTransient<ICreateOrderCommand, EFCreateOrderCommand>();
            services.AddTransient<IRegisterUserCommand, EFRegisterUserCommand>();
            services.AddTransient<IInsertIntoCart, EFInsertIntoCartCommand>();

            services.AddTransient<IUpdateArticleCommand, EFUpdateArticleCommand>();
            services.AddTransient<IUpdateUserCommand, EFUpdateUserCommand>();

            services.AddTransient<IUpdateQuantityCart, EFUpdateQuantityCartCommand>();
            services.AddTransient<IUpdateCategoryCommand, EFUpdateCategoryCommand>();
            services.AddTransient<IChangeOrderStatus, EFChangeOrderStatusCommand>();

            services.AddTransient<IDeleteArticleCommand, EFDeleteArticleCommand>();
            services.AddTransient<IDeleteCategory, EFDeleteCategoryCommand>();
            services.AddTransient<IDeleteUserCommand, EFDeleteUserCommand>();
            services.AddTransient<IDeleteProductFromCart, EFDeleteProductFromCartCommand>();

        }

        public static void AddAllQueries(this IServiceCollection services)
        {
            services.AddTransient<IAuditLogs, EFAuditLogs>();
            services.AddTransient<IGetOneUserQuery, EFGetOneUserQuery>();
            services.AddTransient<IGetUsersQuery, EFGetUsersQuery>();
            services.AddTransient<IGetOneArticleQuery, EFGetOneArticleQuery>();
            services.AddTransient<IGetArticlesQuery, EFGetArticlesQuery>();
            services.AddTransient<IGetOneCategoryQuery, EFGetOneCategoryQuery>();
            services.AddTransient<IGetCategoriesQuery, EFGetCategoriesQuery>();
            services.AddTransient<IGetOrder, EFGetOrder>();
            services.AddTransient<IGetOrdersQuery, EFGetOrdersQuery>();
            services.AddTransient<IGetUserCart, EFGetUserCartQuery>();

        }
    }
}
