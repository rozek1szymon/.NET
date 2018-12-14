using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using ToDoApp.Models;

namespace ToDoApp.DAL
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(): base ("connectionString")
        {

        }
        public DbSet<ToDo> ToDo { get; set; }
    }
}