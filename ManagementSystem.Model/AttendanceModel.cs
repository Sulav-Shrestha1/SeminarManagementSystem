using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Model
{
    public class AttendanceModel
    {
        [Required]
        [Display(Name ="Attendance ID")]
        public int AttendanceID { get; set; }
        [Required]
        [Display(Name = "Seminar Title")]
        public int? SeminarID { get; set; }
        [Required]
        [Display(Name = "Attendee Name")]
        public int? AttendeeID { get; set; }
        [Required]
        [Display(Name = "Available")]
        public string IsAvailable { get; set; }

        public AttendeeModel Attendee { get; set; }
        public SeminarModel Seminar { get; set; }
    }
}
