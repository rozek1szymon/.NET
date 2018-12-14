using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WebHospital.Models
{
    /// <summary>
    /// This is our class which is conected to the base
    /// </summary>
    public class doctor
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public bool? Availability { get; set; }
    }
    
}
