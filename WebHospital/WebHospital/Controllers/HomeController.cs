using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebHospital.Models;
using System.Net;
using System.Net.Mail;
using WebHospital.Models;
using System.Linq;
using TextmagicRest;
using TextmagicRest.Model;
using System.Security.Cryptography;
using System.Text;
using System.Web.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Logging;

namespace WebHospital.Controllers
{
    public class HomeController : Controller
    {
        protected MainDb mContext;
        protected UserManager<Patients> mUserManager;
        protected SignInManager<Patients> mSignInManager;
        protected ILogger mLogger;

        public HomeController(
            MainDb context,
            UserManager<Patients> userManager,
            SignInManager<Patients> SignInManager,
            ILogger<HomeController> logger)
        {
            mContext = context;
            mUserManager = userManager;
            mSignInManager = SignInManager;
            mLogger = logger;

        }






        /// <summary>
        /// first of all you have to create public function of type: "ViewResult" because we are returning type View("MyView") so we have to have this class in our Views/Home, and name of function has to be a "Index"
        /// because we have route action which name is "Index", but this principle is only to the first loading page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View("MyView");
        public IActionResult MainLogPanel() => View("MainLogPanel");
        public IActionResult ShowAllDoctors()
        {
            // context.patients.Add(patient);
            // context.SaveChanges();


            return View();
        }
        [HttpGet]
        public IActionResult Registration() => View();

        [HttpPost]
        public async Task<IActionResult> Registration(Patients patient, gmail model)
        {
            var result = await mUserManager.CreateAsync(new Patients
            {
                UserName = patient.UserName,
                Email = patient.Email



            }, patient.PasswordHash);

            if (ModelState.IsValid)
            {

               if(result.Succeeded)
                {
                    return View("WriteCode", patient);
                }


                //Random rnd = new Random();
                //int activationCode = rnd.Next(100000, 999999);
                //model.ToWho = patient.Email;
                //MailMessage mm = new MailMessage("mvclearn@gmail.com", model.ToWho);
                //mm.Subject = "Aktywacja konta w serwisie Szymon";

                //mm.Body = $"Dziękujemy za zarejstorwanie się w naszym serwisie, twój kod aktywacyjny to {activationCode}";
                //mm.IsBodyHtml = false;


                //SmtpClient smtp = new SmtpClient();
                //smtp.Host = "smtp.gmail.com";
                //smtp.Port = 587;
                //smtp.EnableSsl = true;
                //NetworkCredential nc = new NetworkCredential("mvclearn@gmail.com", "MvcJestSuper");
                //smtp.UseDefaultCredentials = true;
                //smtp.Credentials = nc;
                //smtp.Send(mm);
                //ViewBag.Activation = activationCode;
                //ViewBag.Message = "Mail has been sent successfully!";

                return View();
            }
            else
            {
                return View();

            }


        }



        //[HttpPost]
        //public IActionResult WriteCode(Patients patient)
        //{
        //   // patient.Password = Hashing.Hash(patient.Password);
        //   /// context.patients.Add(patient);
        //   // context.SaveChanges();
        //   // var emails = context.patients.Where(e => e.Email == "rozek1szymon@gmail.com").Select(e => e.Name).ToArray();
        //   //  ViewBag.Message = emails;

        //  //  return View("Thanks",emails);








        //}
        [Authorize(AuthenticationSchemes = "Identity.Application,Bearer")]
         //[Authorize]
        [Route("private")]
        public IActionResult Private()
        {
            return Content($"This is a private area. Welcome {HttpContext.User.Identity.Name}", "text/html");

        }

        [HttpGet]
        public IActionResult Login() => View();

        
        [HttpPost]  
        public async Task<IActionResult> Login(LoginUser newpatient, string returnUrl)
        {
             await HttpContext.SignOutAsync();
             //var correct = mContext.Users.Where(e => e.Email == newpatient.Email).FirstOrDefault();
             var result = await mSignInManager.PasswordSignInAsync(newpatient.Email, newpatient.Password, true, false);
             
            //if (correct != null)
            // {
            if (result.Succeeded)
                {
                if (string.IsNullOrEmpty(returnUrl))
                    return RedirectToAction(nameof(Index));

                   return Redirect(returnUrl);
                }


            //  }

            
            return View("Logged", ViewBag);






            //}

            //public IActionResult ListResponses() =>
            //View(context.doctors.OrderBy(r => r));
        }
    }
}




