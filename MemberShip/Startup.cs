using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using DAL;
using DAL.Core;
using DAL.Core.Interfaces;
using DAL.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace MemberShip
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SystemConnection")
            , b => b.MigrationsAssembly("MemberShip")));

            // add identity
            services.AddIdentity<ApplicationUser, ApplicationRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            // Configure Identity options and password complexity here
            services.Configure<IdentityOptions>(options =>
            {
                // User settings
                options.User.RequireUniqueEmail = true;

                // Password settings
                options.Password.RequireDigit = false;
                //options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;

                //    //// Lockout settings
                //    //options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(30);
                //    //options.Lockout.MaxFailedAccessAttempts = 10;
            });

            services.AddControllersWithViews();
            
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = "UserAuth";
            })
            .AddCookie("UserAuth", options =>
            {
                options.LoginPath = "/Account/Login/";
                options.AccessDeniedPath = "/Account/AccessDenied/";

            })
           .AddCookie("AdminAuth", options =>
           {
               options.LoginPath = "/Admin/Account/Login";
               options.AccessDeniedPath = "/Account/AccessDenied/";
               //options.LoginPath = "/Admin/Account/Login/";
               //options.AccessDeniedPath = "/Admin/Account/AccessDenied/";

           });
            //services.ConfigureApplicationCookie(options =>
            //{
            //    // Cookie settings
            //    options.Cookie.HttpOnly = true; // define the cookie for http/https requests only
            //    options.LoginPath = "/Identity/Account/Login"; // Set here login path.
            //    options.AccessDeniedPath = "/Identity/Account/AccessDenied"; // set here access denied path.
            //    options.SlidingExpiration = true; // resets cookie expiration if more than half way through lifespan
            //    options.ExpireTimeSpan = TimeSpan.FromHours(24); // cookie validation time
            //    options.Cookie.Name = "myExampleCookie"; // name of the cookie saved to user's browsers
            //});
            //services.ConfigureApplicationCookie(options =>
            //{
            //    options.LoginPath = "/Admin/Account/Login";
            //    options.LogoutPath = "/Admin/Accountyyy/Logout";
            //    options.AccessDeniedPath = "/Admin/Account/AccessDenied";
            //});
            //services.AddRazorPages()
            //    .AddRazorPagesOptions(options =>
            //    {
            //        options.Conventions.AuthorizeAreaPage("Admin", "/Admin/Account/Register");
            //        //options.Conventions.AuthorizeAreaFolder("Admin", "/Admin/Account");
            //        //options.Conventions.AuthorizeAreaPage("Admin", "/Index");
            //        //options.Conventions.AuthorizeAreaFolder("Admin", "/Users");
            //        //options.Conventions.AuthorizeAreaFolder("Identity", "/Account/Manage");
            //    });

            services.AddAutoMapper(typeof(Startup));

            // Repositories
            services.AddScoped<IUnitOfWork, HttpUnitOfWork>();
            services.AddScoped<IAccountManager, AccountManager>();

            // DB Creation and Seeding
            services.AddTransient<IDatabaseInitializer, DatabaseInitializer>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

   
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                   name: "admin",
                   pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
