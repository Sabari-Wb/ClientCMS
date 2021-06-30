using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCMS.Models
{
    public class Login
    {
        [Required]
        [RegularExpression("^[A-za-z0-9]*$", ErrorMessage = "Alphabets and numbers only allowed")]
        [MinLength(6, ErrorMessage = "The user Name must be atleast 6 characters")]
        [MaxLength(20, ErrorMessage = "The user Name cannot be more than 20characters")]
        [Key]
        public string UserName { get; set; }
        [Required]

        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
