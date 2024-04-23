using AutoMapper;
using Business.Authentication.Concrete.SignService;
using Business.Authentication.Concrete.TokenService;
using Business.Authentication.Interfaces.SignServiceInterfaces;
using Business.Authentication.Interfaces.TokenManagerInterfaces;
using DataAccess.DbContext;
using DataAccess.Interfaces.SignRepositories;
using DataAccess.Interfaces.UserRepositories;
using DataAccess.Repositories.SignRepositories;
using DataAccess.Repositories.UserRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Models.Entities;
using Shared.Mapper;
using System.Text;

namespace AuthForAnyone.Extensions
{
    public static class ServiceExtensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<EFContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                ));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ISignService, SignService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISignRepository, SignRepository>();
            services.AddScoped<ITokenManager, TokenManager>();
            services.AddScoped<ITokenManagerFactory, TokenManagerFactory>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        public static void ConfigureIdentities(this IServiceCollection services)
        {
            services.AddIdentity<User, Role>(opts =>
                {
                    opts.Password.RequireDigit = true;
                    opts.Password.RequireLowercase = false;
                    opts.Password.RequireUppercase = false;
                    opts.Password.RequireNonAlphanumeric = false;
                    opts.Password.RequiredLength = 6;

                    opts.User.RequireUniqueEmail = true;
                })
                .AddEntityFrameworkStores<EFContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();
        }

        public static void ConfigureAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        public static void ConfigureJwtBearer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(
                    authenticationScheme: JwtBearerDefaults.AuthenticationScheme,
                    configureOptions: options =>
                    {
                        options.IncludeErrorDetails = true;
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            IssuerSigningKey =
                                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:PrivateKey"])),
                            ValidAudience = configuration["JWT:Audience"],
                            ValidIssuer = configuration["JWT:Issuer"],
                            RequireExpirationTime = true,
                            RequireAudience = true,
                            ValidateIssuer = true,
                            ValidateLifetime = true,
                            ValidateAudience = true,
                        };
                    });
        }
    }
}
