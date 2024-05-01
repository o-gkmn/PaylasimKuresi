using AutoMapper;
using Business.Authentication.Concrete.SignService;
using Business.Authentication.Concrete.TokenService;
using Business.Authentication.Interfaces.SignServiceInterfaces;
using Business.Authentication.Interfaces.TokenManagerInterfaces;
using Business.PaylasimKuresi.Interfaces.CommentLikeServices;
using Business.PaylasimKuresi.Interfaces.CommentServices;
using Business.PaylasimKuresi.Interfaces.CommunityServices;
using Business.PaylasimKuresi.Interfaces.CommunityUserServices;
using Business.PaylasimKuresi.Interfaces.DmServices;
using Business.PaylasimKuresi.Interfaces.FollowServices;
using Business.PaylasimKuresi.Interfaces.GroupServices;
using Business.PaylasimKuresi.Interfaces.GroupUserServices;
using Business.PaylasimKuresi.Interfaces.ImagePostServices;
using Business.PaylasimKuresi.Interfaces.PostServices;
using Business.PaylasimKuresi.Interfaces.RoleServices;
using Business.PaylasimKuresi.Interfaces.TextPostServices;
using Business.PaylasimKuresi.Interfaces.UserServices;
using Business.PaylasimKuresi.Interfaces.VideoPostServices;
using Business.PaylasimKuresi.Interfaces.VoicePostServices;
using Business.PaylasimKuresi.Services.CommentLikeServices;
using Business.PaylasimKuresi.Services.CommentServices;
using Business.PaylasimKuresi.Services.CommunityServices;
using Business.PaylasimKuresi.Services.CommunityUserServices;
using Business.PaylasimKuresi.Services.DmServices;
using Business.PaylasimKuresi.Services.FollowServices;
using Business.PaylasimKuresi.Services.GroupServices;
using Business.PaylasimKuresi.Services.GroupUserServices;
using Business.PaylasimKuresi.Services.ImagePostServices;
using Business.PaylasimKuresi.Services.PostServices;
using Business.PaylasimKuresi.Services.RoleServices;
using Business.PaylasimKuresi.Services.TextPostServices;
using Business.PaylasimKuresi.Services.UserServices;
using Business.PaylasimKuresi.Services.VideoPostServices;
using Business.PaylasimKuresi.Services.VoicePostServices;
using DataAccess.DbContext;
using DataAccess.Interfaces.CommentLikeRepositories;
using DataAccess.Interfaces.CommentRepositories;
using DataAccess.Interfaces.CommunityRepositories;
using DataAccess.Interfaces.CommunityUserRepositories;
using DataAccess.Interfaces.DmRepositories;
using DataAccess.Interfaces.FollowRepositories;
using DataAccess.Interfaces.GroupRepositories;
using DataAccess.Interfaces.GroupUserRepositories;
using DataAccess.Interfaces.ImagePostRepositories;
using DataAccess.Interfaces.PostRepositories;
using DataAccess.Interfaces.RoleRepositories;
using DataAccess.Interfaces.SignRepositories;
using DataAccess.Interfaces.TextPostRepositories;
using DataAccess.Interfaces.UserRepositories;
using DataAccess.Interfaces.VideoPostRepositories;
using DataAccess.Interfaces.VoicePostRepositories;
using DataAccess.Repositories.CommentLikeRepositories;
using DataAccess.Repositories.CommentRepositories;
using DataAccess.Repositories.CommunityRepositories;
using DataAccess.Repositories.CommunityUserRepositories;
using DataAccess.Repositories.DmRepositories;
using DataAccess.Repositories.FollowRepositories;
using DataAccess.Repositories.GroupRepositories;
using DataAccess.Repositories.GroupUserRepositories;
using DataAccess.Repositories.ImagePostRepositories;
using DataAccess.Repositories.PostRepositories;
using DataAccess.Repositories.RoleRepositories;
using DataAccess.Repositories.SignRepositories;
using DataAccess.Repositories.TextPostRepositories;
using DataAccess.Repositories.UserRepositories;
using DataAccess.Repositories.VideoPostRepositories;
using DataAccess.Repositories.VoicePostRepositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Models.Entities;
using Shared.Mapper;
using System.Text;

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
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IRoleService, RoleService>();
        services.AddScoped<ISignService, SignService>();
        services.AddScoped<ICommentLikeService, CommentLikeService>();
        services.AddScoped<ICommentService, CommentService>();
        services.AddScoped<ICommunityService, CommunityService>();
        services.AddScoped<ICommunityUserService, CommunityUserService>();
        services.AddScoped<IDmService, DmService>();
        services.AddScoped<IFollowService, FollowService>();
        services.AddScoped<IGroupService, GroupService>();
        services.AddScoped<IGroupUserService, GroupUserService>();
        services.AddScoped<IImagePostService, ImagePostService>();
        services.AddScoped<IPostService, PostService>();
        services.AddScoped<ITextPostService, TextPostService>();
        services.AddScoped<IVideoPostService, VideoPostService>();
        services.AddScoped<IVoicePostService, VoicePostService>();
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
        services.AddScoped<ISignRepository, SignRepository>();
        services.AddScoped<ITokenManager, TokenManager>();
        services.AddScoped<ITokenManagerFactory, TokenManagerFactory>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();
        services.AddScoped<ICommentLikeRepository, CommentLikeRepository>();
        services.AddScoped<ICommentRepository, CommentRepository>();
        services.AddScoped<ICommunityRepository, CommunityRepository>();
        services.AddScoped<ICommunityUserRepository, CommunityUserRepository>();
        services.AddScoped<IDmRepository, DmRepository>();
        services.AddScoped<IFollowRepository, FollowRepository>();
        services.AddScoped<IGroupRepository, GroupRepository>();
        services.AddScoped<IGroupUserRepository, GroupUserRepository>();
        services.AddScoped<IImagePostRepository, ImagePostRepository>();
        services.AddScoped<IPostRepository, PostRepository>();
        services.AddScoped<ITextPostRepository, TextPostRepository>();
        services.AddScoped<IVideoPostRepository, VideoPostRepository>();
        services.AddScoped<IVoicePostRepository, VoicePostRepository>();
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

        var mapper = config.CreateMapper();
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
