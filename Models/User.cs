using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCMS.Models
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter correct name")]
        [MinLength(3, ErrorMessage = "The First Name must be atleast 3 characters")]
        [MaxLength(20, ErrorMessage = "The First Name cannot be more than 20characters")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets are allowed")]
        public string FirstName { get; set; }
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "Please enter correct name")]
        [MinLength(3, ErrorMessage = "The last Name must be atleast 3 characters")]
        [MaxLength(20, ErrorMessage = "The last Name cannot be more than 20characters")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Only Alphabets are allowed")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "please enter the emailID")]
        [DataType(DataType.EmailAddress)]
        public string EmailID { get; set; }
        [Required]
        [RegularExpression("^[A-za-z0-9]*$", ErrorMessage = "Alphabets and numbers only allowed")]
        [MinLength(6, ErrorMessage = "The user Name must be atleast 6 characters")]
        [MaxLength(20, ErrorMessage = "The user Name cannot be more than 20characters")]
        public string Username { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
        [NotMapped]
        [Compare("Password", ErrorMessage = "The fields Password and PasswordConfirmation should be equals")]
        [DataType(DataType.Password)]
        public string PasswordConfirmation { get; set; }
        [Required(ErrorMessage = "Gender is Required")]
        public string Sex { get; set; }
    }
}

