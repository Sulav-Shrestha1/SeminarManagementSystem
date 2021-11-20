using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Model
{
    public class AccountModel
    {
        [Required]

        public int AccountID { get; set; }
        [Required(ErrorMessage = "The Username Field is Required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "The Password Field is Required")]
        public string Password { get; set; }
        [Required(ErrorMessage = "The Email Field is Required")]
        [EmailAddress]
        public string Email { get; set; }
        [Display(Name = "Available")]
        public string IsAvailable { get; set; }
    }
}
