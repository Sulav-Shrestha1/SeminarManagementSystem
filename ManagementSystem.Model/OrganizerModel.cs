using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Model
{
    public class OrganizerModel
    {
        [Display(Name = "Organizer ID")]
        public int OrganizerID { get; set; }
        [Required]
        [Display(Name = "Organizer Name")]
        public string OrganizerName { get; set; }
        [Display(Name = "Email")]
        public string OrganizerEmail { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string OrganizerAddress { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string OrganizerPhone { get; set; }
        [Display(Name = "Available")]
        public string IsAvailable { get; set; }

    }
}
