using Microsoft.AspNetCore.Mvc;
using System;
using PartyInvites.Models;
using System.Linq;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            //setting view data in the controller
            int hour = DateTime.Now.Hour;
            // we are using ViewBag beacuse we need to send it to the our MyView in home 
            ViewBag.Greeting = hour < 12 ? "Good Morning" : "Good Afternoon";
            return View("MyView");
        }
        /// <summary>
        ///   This tells MVC that this method should be used only for GET requests.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ViewResult RsvpForm()
        {
            return View();
        }
        /// <summary>
        /// tells MVC that the new method will deal with POST requests.
        /// </summary>
        /// <param name="guestResponse"></param>
        /// <returns></returns>
        [HttpPost]
        // we are creating function which adding our guests to a list
        public ViewResult RsvpForm(GuestResponse guestResponse)
        {
            if (ModelState.IsValid)
            {
                Repository.AddResponse(guestResponse);
                return View("Thanks", guestResponse);
            }
            else
            {
                // there is a validation error
                return View();
            }

        }

        public ViewResult ListResponses()
        {
            return View(Repository.Responses.Where(r => r.WillAttend == true));
        }
    }
}
