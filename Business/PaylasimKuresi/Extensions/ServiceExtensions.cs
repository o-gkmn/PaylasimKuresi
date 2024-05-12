using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using Business.Authentication.Concrete.SignService;
using Business.Authentication.Interfaces.SignServiceInterfaces;
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
using DataAccess.Repositories.TextPostRepositories;
using DataAccess.Repositories.UserRepositories;
using DataAccess.Repositories.VideoPostRepositories;
using DataAccess.Repositories.VoicePostRepositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models.Entities;
using Shared.Mapper;

namespace Business.PaylasimKuresi.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<EFContext>(
            options => options.UseLazyLoadingProxies()
                    .UseSqlServer(configuration.GetConnectionString("DefaultConnection")
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
        services.AddScoped<ISignService, SignService>();
    }

    public static void ConfigureRepositories(this IServiceCollection services)
    {
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

    public static void ConfigureApplicationCookie(this IServiceCollection services)
    {
        services.ConfigureApplicationCookie(option =>
            {
                option.LoginPath = "/SignIn/";
                option.LogoutPath = "/account/logout";
                option.AccessDeniedPath = "/account/accessdenied";
                option.SlidingExpiration = true;
                option.ExpireTimeSpan = TimeSpan.FromMinutes(36);

                option.Cookie = new CookieBuilder
                {
                    HttpOnly = true,
                    Name = ".Shopapp.Security.Cookie",
                    SameSite = SameSiteMode.Strict
                };
            });
    }

    public static void ConfigureAutoMapper(this IServiceCollection services)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.AddExpressionMapping();
            cfg.AddProfile<MapperProfile>();
        });

        var mapper = config.CreateMapper();
        services.AddSingleton(mapper);
    }
}
