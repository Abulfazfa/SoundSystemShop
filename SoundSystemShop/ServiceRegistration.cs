﻿using Microsoft.AspNetCore.Identity;
using SoundSystemShop.DAL;
using SoundSystemShop.Models;
using SoundSystemShop.Services.Interfaces;
using SoundSystemShop.Services;

namespace SoundSystemShop
{
    public static class ServiceRegistration
    {
        public static void ServiceRegister(this IServiceCollection services)
        {
            services.AddControllersWithViews();

            services.AddSession(option =>
            {
                option.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddHttpContextAccessor();
            services.AddIdentity<AppUser, IdentityRole>(option =>
            {
                option.Password.RequiredLength = 8;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireUppercase = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireDigit = true;

                option.User.RequireUniqueEmail = true;
                option.Lockout.AllowedForNewUsers = true;
                option.Lockout.MaxFailedAccessAttempts = 3;
                option.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<ISliderRepository, SliderRepository>();
            services.AddSignalR();
        }
    }
}
