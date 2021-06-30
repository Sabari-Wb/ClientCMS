using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCMS.Models
{
    public class Patient
    {
        public int PatientID { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter correct name")]
        [MinLength(3, ErrorMessage = "The First Name must be atleast 3 characters")]
        [MaxLength(20, ErrorMessage = "The First Name cannot be more than 20characters")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets are allowed")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter name")]
        [MinLength(3, ErrorMessage = "The First Name must be atleast 3 characters")]
        [MaxLength(20, ErrorMessage = "The First Name cannot be more than 20 characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public string Sex { get; set; }
        [Required(ErrorMessage = "Age is Required")]
        [Range(1, 120, ErrorMessage = "Age must be between 1-120 in years.")]
        public int Age { get; set; }


        [DataType(DataType.Date)]
        public DateTime Dateofbirth { get; set; }
        [Required(ErrorMessage = "Phone Number Required")]
        [StringLength(10, ErrorMessage = "phone number should be 10 digits")]
        [RegularExpression("[0-9]*$", ErrorMessage = "only numbers should be entered")]
        public string ContactNumber { get; set; }

    }


}

