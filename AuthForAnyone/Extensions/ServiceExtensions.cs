﻿using AutoMapper;
using Core.Interfaces;
using Core.Services;
using DataAccess.DbContext;
using DataAccess.Interfaces;
using DataAccess.Repositories;
using Identity.Models;
using Infrastructure.Mapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace AuthForAnyone.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AuthContext>(
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
}