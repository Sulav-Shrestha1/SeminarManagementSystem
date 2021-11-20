using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Model
{
    public class AttendeeModel
    {
        [Display(Name = "Attendee ID")]
        public int AttendeeID { get; set; }
        [Required]
        [Display(Name = "Attendee Name")]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Gender { get; set; }
        public string Occupation { get; set; }

        [Required]
        public string Phone { get; set; }
        public string Address { get; set; }
        [Display(Name = "Available")]
        public string IsAvailable { get; set; }

    }
}
