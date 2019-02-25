using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using WebHospital.Models;
namespace WebHospital.Models
{
    /// <summary>
    /// We create database which has "doctor" variables we create a constructor too, like this below
    /// </summary>
    public class MainDb : IdentityDbContext<Patients>
    {
        public MainDb(DbContextOptions<MainDb> options) : base(options)
        {

        }
        
       // public DbSet<doctor> doctors { get; set; }
       //public DbSet<Patients> patients { get; set; }
        public DbSet<doctor> doctors { get; set; }



    }
}
