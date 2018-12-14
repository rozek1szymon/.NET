using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Linq;

namespace EntityFrameworkBasics.Controllers
{
    public class HomeController : Controller
    {

        protected ApplicationDbContext mContext;

        public HomeController(ApplicationDbContext context)
        {
            mContext = context;
        }

        public IActionResult Index()
        {






            mContext.Database.EnsureCreated();

            if (!mContext.Settings.Any()) // this if checks if a database has any elements
            {
                mContext.Settings.Add(new SettingsDataModel //it creates a new element in a database
                {
                    Name = "Simon",
                    Value = "Master"
                });

                // var localNumberOfSettings = context.Settings.Local.Count(); /// it show us local number of added elements bout not this from database
                var numberOfSettings = mContext.Settings.Count(); //returns a number of elements

                //var firstSettings = context.Settings.First(); // return the first element

                mContext.SaveChanges(); // it save every change to our database
            }



            return View();
        }

        
    }
}
