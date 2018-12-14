using System;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
namespace MvcMovie.Models
{
    public class Movie
    {
        public int ID { get; set; }
        public string Title { get; set; }
        [Display(Name = "Date")] // it display on a page word "Date" near the date box
        [DataType(DataType.Date)] // we can choose from a table which day we want
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)] // in an edit mode we dont have to add seconds only a day
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public decimal Price { get; set; }
    }

    public class MovieDBContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}