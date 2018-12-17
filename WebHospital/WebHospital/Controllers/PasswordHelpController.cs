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

namespace WebHospital.Controllers
{
    public class PasswordHelpController : Controller
    {
        private MainDb context;
        public PasswordHelpController(MainDb ctx) => context = ctx;
           

            
        [HttpGet]
        public IActionResult passwordhelp() => View();

        [HttpPost]
        public IActionResult passwordhelp(string EmailID)
        {
            var account = context.patients.Where(x => x.Email == EmailID).FirstOrDefault();
            if(account!=null)
            {

            }
            else
            {
                ViewBag.message = "Account not found";
            }

            return View();
        }


    }
}