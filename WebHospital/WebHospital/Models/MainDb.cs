using Microsoft.EntityFrameworkCore;
using System;
using WebHospital.Models;
namespace WebHospital.Models
{
    /// <summary>
    /// We create database which has "doctor" variables we create a constructor too, like this below
    /// </summary>
    public class MainDb : DbContext 
    {
        public MainDb(DbContextOptions<MainDb> options) : base(options)
        {

        }
        
       // public DbSet<doctor> doctors { get; set; }
       public DbSet<Patients> patients { get; set; }


        
    }
}
