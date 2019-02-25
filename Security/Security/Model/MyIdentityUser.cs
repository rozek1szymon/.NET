﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Security.Model
{
    public class MyIdentityUser : IdentityUser
    {
        public string FullName { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
