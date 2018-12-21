using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginWithIdentity.Models
{
    public class Db : DbContext
    {
        public Db(DbContextOptions<Db> options) : base(options)
        {

        }

        // public DbSet<doctor> doctors { get; set; }
        public DbSet<UserOfProgram> patients { get; set; }
        
    }
}
