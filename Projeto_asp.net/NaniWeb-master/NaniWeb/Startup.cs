using System;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NaniWeb.Data;
using NaniWeb.Services;

namespace NaniWeb
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<NaniDb>(builder =>
            {
                var stringBuilder = new StringBuilder();

                stringBuilder.Append($"Host={_configuration.GetValue<string>("Database:Host")};");
                stringBuilder.Append($"Database={_configuration.GetValue<string>("Database:DBName")};");
                stringBuilder.Append($"Username={_configuration.GetValue<string>("Database:Username")};");
                stringBuilder.Append($"Password={_configuration.GetValue<string>("Database:Password")}");

                builder.UseNpgsql(stringBuilder.ToString());
            });

            services.AddIdentity<IdentityUser<Guid>, IdentityRole<Guid>>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromHours(3);
                options.Lockout.MaxFailedAccessAttempts = 3;
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;
                options.User.RequireUniqueEmail = true;
            }).AddEntityFrameworkStores<NaniDb>().AddDefaultTokenProviders();

            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = false;
                options.LowercaseQueryStrings = true;
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/admin";
                options.LogoutPath = "/admin/logout";
                options.AccessDeniedPath = "/denied";
                options.ReturnUrlParameter = "originPath";
            });

            services.AddControllersWithViews();

            services.AddTransient<EmailSender>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/error");
            }

            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(builder =>
            {
                builder.MapControllerRoute("Authentication", "admin/{action=SignIn}", new {controller = "Authentication"});
                builder.MapControllerRoute("User", "admin/user/{action}", new {controller = "User"});
            });
        }
    }
}