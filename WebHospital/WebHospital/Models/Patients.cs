using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WebHospital.Models
{
    public class Patients
    {
        public long ID { get; set; }


        [Required (ErrorMessage = "Pesel must have 11 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Pesel contains  11 numbers")]
        public string Pesel { get; set; }

        

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name contains only letters")]
        [Required(ErrorMessage = "Name contains only letters")]
        [StringLength(30)]
        public string Name { get; set; }

        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Surname contains only letters")]
        [Required (ErrorMessage = "Surname contains only letters")]
        [StringLength(30)]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Write email down")]
        [RegularExpression(".+\\@.+\\..+",ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Write phone number down")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number contain of letters only")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Write date of your birth down")]
        [DisplayFormat(DataFormatString = "{0:d}")]
        public DateTime? Date{ get; set; }
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// we are creating private list of Patients
        /// </summary>

    }
}
