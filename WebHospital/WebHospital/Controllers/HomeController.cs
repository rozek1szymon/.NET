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


namespace WebHospital.Controllers
{
    public class HomeController : Controller
    {
        private MainDb context;
        public HomeController(MainDb ctx) => context = ctx;
       
        /// <summary>
        /// first of all you have to create public function of type: "ViewResult" because we are returning type View("MyView") so we have to have this class in our Views/Home, and name of function has to be a "Index"
        /// because we have route action which name is "Index", but this principle is only to the first loading page
        /// </summary>
        /// <returns></returns>
        public IActionResult Index() => View("MyView");
        public IActionResult ShowAllDoctors()
        {
            // context.patients.Add(patient);
            // context.SaveChanges();


            return View();
        }
        [HttpGet]
        public IActionResult Registration() => View();
        
        [HttpPost]
        public  IActionResult Registration(Patients patient, gmail model)
        {
           


           


            



            
            if (ModelState.IsValid)
            {
                Random rnd = new Random();
                int activationCode = rnd.Next(100000, 999999);
                model.ToWho = patient.Email;
                MailMessage mm = new MailMessage("mvclearn@gmail.com", model.ToWho);
                mm.Subject = "Aktywacja konta w serwisie Szymon";

                mm.Body = $"Dziękujemy za zarejstorwanie się w naszym serwisie, twój kod aktywacyjny to {activationCode}";
                mm.IsBodyHtml = false;


                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                NetworkCredential nc = new NetworkCredential("mvclearn@gmail.com", "MvcJestSuper");
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = nc;
                smtp.Send(mm);
                ViewBag.Activation = activationCode;
                ViewBag.Message = "Mail has been sent successfully!";
                return View("WriteCode", patient);
            }
            else
            {

                return View();
            }
            

        }

        

        [HttpPost]
        public IActionResult WriteCode(Patients patient)
        {
            context.patients.Add(patient);
            context.SaveChanges();
            var emails = context.patients.Where(e => e.Email == "rozek1szymon@gmail.com").Select(e => e.Name).ToArray();
             ViewBag.Message = emails;
            
            return View("Thanks",emails);
            


           
  
           
                

        }

        //public IActionResult ListResponses() =>
        //View(context.doctors.OrderBy(r => r));
    }
}
