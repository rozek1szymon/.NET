using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using WebHospital.Models;
using Microsoft.AspNetCore.Identity;
using Test;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WebHospital
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            IoCContainer.Configuration = configuration;
        }


        
        public void ConfigureServices(IServiceCollection services)
        {
            
            // we adding this to connect our database with program, and we need to add this which is commented below to the appsettings.json ,ew instead of conString we can add it here 
            // {
          //  "ConnectionStrings": {
          //      "DefaultConnection": "\"\"Server=.;Database=WebHospital;Trusted_Connection=True;MultipleActiveResultSets=true\"\""
          //  }
       //     }
        string conString = IoCContainer.Configuration["ConnectionStrings:DefaultConnection"];
            
            services.AddDbContext<MainDb>(options =>
             options.UseSqlServer(conString));

            services.AddIdentity<Patients, IdentityRole>()
                .AddEntityFrameworkStores<MainDb>()
                .AddDefaultTokenProviders();

            services.AddAuthentication().
                AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = IoCContainer.Configuration["Jwt:Issuer"],
                        ValidAudience = IoCContainer.Configuration["Jwt:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(IoCContainer.Configuration["Jwt:SecretKey"])),

                    };
                });
            

            services.Configure<IdentityOptions>(options =>
            {
                // Make really weak passwords possible
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });


            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/Home/Login";

                options.ExpireTimeSpan = TimeSpan.FromSeconds(15);

            });
            services.AddMvc();
        }

        
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,IServiceProvider serviceProvider)
        {
            IoCContainer.Provider = serviceProvider;
            app.UseAuthentication();
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
         
        }
    }
}

