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
using System;
using Microsoft.AspNetCore.Identity;
using System.Text.Encodings.Web;

namespace WebHospital.Controllers
{
    public class PasswordHelpController : Controller
    {
        

        private MainDb context;
        public PasswordHelpController(MainDb ctx) => context = ctx;


        [HttpGet]
        public IActionResult passwordhelp() => View();

        //[HttpPost]
        //public IActionResult passwordhelp(Patients pat)
        //{
        //   // var account = context.patients.Where(x => x.Email == pat.Email).FirstOrDefault();
        //    if(account!=null)
        //    {
        //      System.Guid activationCode = Guid.NewGuid();
                
        //        MailMessage mm = new MailMessage("mvclearn@gmail.com", pat.Email);
        //        mm.Subject = "Resetacja hasła";
        //        var verifyUrl =  activationCode;
        //        // var link = Request.Url.AbsoluteUri.Replace(Request.Url.PathAndQuery, verifyUrl);
                

        //        mm.Body = $"Please confirm your account";
        //        mm.IsBodyHtml = true;


        //        SmtpClient smtp = new SmtpClient();
        //        smtp.Host = "smtp.gmail.com";
        //        smtp.Port = 587;
        //        smtp.EnableSsl = true;
        //        NetworkCredential nc = new NetworkCredential("mvclearn@gmail.com", "MvcJestSuper");
        //        smtp.UseDefaultCredentials = true;
        //        smtp.Credentials = nc;
        //        smtp.Send(mm);
                
        //        ViewBag.Message = "Mail has been sent successfully!";


        //        return View("Thanks");
        //    }
        //    else
        //    {
        //        ViewBag.message = "Account not found";
        //        return View("WriteCode");
        //    }

           
        //}


    }
}