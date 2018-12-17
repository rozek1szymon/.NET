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


namespace WebHospital
{
    public class Startup
    {
        public Startup(IConfiguration config) => Configuration = config;
        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            // we adding this to connect our database with program, and we need to add this which is commented below to the appsettings.json ,ew instead of conString we can add it here 
            // {
          //  "ConnectionStrings": {
          //      "DefaultConnection": "\"\"Server=.;Database=WebHospital;Trusted_Connection=True;MultipleActiveResultSets=true\"\""
          //  }
       //     }
        string conString = Configuration["ConnectionStrings:DefaultConnection"];
            
            services.AddDbContext<MainDb>(options =>
             options.UseSqlServer(conString));

        }
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=PasswordHelp}/{action=Index}/{id?}");
            });
        }
    }
}

