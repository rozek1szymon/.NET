using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LoginWithIdentity.Models;
using Microsoft.AspNetCore.Identity;
using System.Text.Encodings.Web;
using System.Net.Mail;
using System.Net;

namespace LoginWithIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<UserOfProgram> _userManager;

        public HomeController(
         UserManager<UserOfProgram> userManager,
         UrlEncoder urlEncoder)
        {
            _userManager = userManager;

        }

        [HttpGet]
        public IActionResult Registration() => View();

        [HttpPost]
        public async Task<IActionResult> Registration(UserOfProgram patient, gmail model)
        {

            if (ModelState.IsValid)
            {
                var user = new UserOfProgram { UserName = patient.Email, Email = patient.Email };
                var result = await _userManager.CreateAsync(user, patient.PasswordHash);
                string ctoken = _userManager.GenerateEmailConfirmationTokenAsync(user).Result;
                string ctokenlink = Url.Action("ConfirmEmail", "Account", new
                {
                    userid = user.Id,
                    token = ctoken
                }, protocol: HttpContext.Request.Scheme);
                ViewBag.token = ctokenlink;

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

                return View(patient);
            }
            else
            {

                return View();
            }


        }
    }
}
