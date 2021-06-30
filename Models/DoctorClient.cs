using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCMS.Models
{
    public class DoctorClient
    {
        
        [Key]
        public int DoctorID { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter correct name")]
        [MinLength(3, ErrorMessage = "The First Name must be atleast 3 characters")]
        [MaxLength(20, ErrorMessage = "The First Name cannot be more than 20characters")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets are allowed")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter correct name")]
        [MinLength(3, ErrorMessage = "The First Name must be atleast 3 characters")]
        [MaxLength(20, ErrorMessage = "The First Name cannot be more than 20characters")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets are allowed")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public string Sex { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter correct specialization field name")]
        [MaxLength(50, ErrorMessage = "The First Name cannot be more than 50characters")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets are allowed")]
        public string Specialization { get; set; }
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Visiting hours is Required")]
        public DateTime VisitingHoursFROM { get; set; }
        [DataType(DataType.Time)]
        [Required(ErrorMessage = "Visiting hours is Required")]
        public DateTime VisitingHoursTO { get; set; }
    }

}

