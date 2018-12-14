using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;


namespace WebHospital.Models
{
    public class DbOfPatients 
    {
        
        private static List<Patients> hospitalPatients = new List<Patients>();
        public static IEnumerable<Patients> Hospitalpatients => hospitalPatients;
        /// <summary>
        /// We can add a new patient to our list of patients 
        /// </summary>
        /// <param name="hospitaladd"></param>
        public static void AddPatient(Patients hospitaladd)
        {
            hospitalPatients.Add(hospitaladd);
        }
        
    }
}
