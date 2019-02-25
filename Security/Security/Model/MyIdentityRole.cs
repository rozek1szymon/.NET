using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Model
{
    public class MyIdentityRole:IdentityRole
    {
        public string Description { get; set; }
    }
}
