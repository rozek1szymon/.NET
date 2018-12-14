﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;

namespace WebHospital.Models
{
    public class Patients
    {

        [Required (ErrorMessage = "Pesel must have 11 numbers")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Pesel contains  11 numbers")]
        public int Pesel { get; set; }

        public long ID { get; set; }

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

        
        [Required(ErrorMessage = "Write number down")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Phone number contain of letters only")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Date is required")]
       
        public DataType Data { get; set; }
        /// <summary>
        /// we are creating private list of Patients
        /// </summary>
       
    }
}
