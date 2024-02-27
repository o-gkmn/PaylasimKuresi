using AuthenticationServiceApi.Business.Services.Abstract;
using AuthenticationServiceApi.Business.Services.Concrete;
using AuthenticationServiceApi.Data.Context;
using AuthenticationServiceApi.Data.Repositories.Abstract;
using AuthenticationServiceApi.Data.Repositories.Concrete;
using AuthenticationServiceApi.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationServiceApi.Extensions
{
    public static class Extensions
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AuthContext>(
                options => options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")
                ));
        }

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddScoped<ISignUpService, SignUpService>();
        }

        public static void ConfigureRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISignUpRepository, SignUpRepository>();
        }

        public static void ConfigureIdentities(this IServiceCollection services)
        {
            services.AddIdentity<UserEntity, RoleEntity>(opts =>
            {
                opts.Password.RequireDigit = true;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequiredLength = 6;

                opts.User.RequireUniqueEmail = true;
            })
                .AddEntityFrameworkStores<AuthContext>()
                .AddDefaultTokenProviders();
        }
    }
}
