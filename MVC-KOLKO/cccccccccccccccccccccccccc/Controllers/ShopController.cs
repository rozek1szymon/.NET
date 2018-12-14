using cccccccccccccccccccccccccc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace cccccccccccccccccccccccccc.Controllers
{
    public class ShopController : Controller
    {
       

        // GET: Shop
        public ActionResult Browse()
        {
            var genres = GetGenres();
            return View(genres);
        }

        public ActionResult Details(int Id)
        {
            var genres = GetGenres();

            Genre genre = genres.Where(x => x.GenreId == Id).FirstOrDefault(); //or   Genre genre = genres.FirstOrDefault(x => x.GenreId == Id);

            return View(genre);
        }






        private  List<Genre> GetGenres()
        {
            var hiphop = new Genre()
            {
                GenreId = 1,
                Name = "hiphop",
                Description = "to jest hiphop"
            };

            var rock = new Genre()
            {
                GenreId = 2,
                Name = "rock",
                Description = "to jest rock"
            };

            var classic = new Genre()
            {
                GenreId = 3,
                Name = "classic",
                Description = "to jest classic"
            };

            List<Genre> genres = new List<Genre>
            {
                hiphop,
                rock,
                classic

            };

            return genres;
        }
    }
}