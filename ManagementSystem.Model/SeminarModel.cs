using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ManagementSystem.Model
{
    public class SeminarModel
    {
        [Display(Name="Seminar ID")]
        public int SeminarID { get; set; }
        [Required]
        [Display(Name = "Seminar Title")]
        public string SeminarTitle { get; set; }
        [Required]
        [Display(Name = "Teacher")]
        public string SeminarTeacher { get; set; }

        [Display(Name = "Room No.")]
        public string SeminarRoom { get; set; }
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Date")]
        public System.DateTime SeminarDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "Start Time")]
        public System.DateTime SeminarStartTime { get; set; }
        [Required]
        [DataType(DataType.Time)]
        [Display(Name = "End Time")]
        public System.DateTime SeminarEndTime { get; set; }
        [Required]
        [Display(Name = "Description")]
        public string SeminarDesc { get; set; }
        [Required]
        [Display(Name = "Type")]
        public string SeminarType { get; set; }
        [Display(Name = "Available")]
        public string IsAvailable { get; set; }
        [Display(Name = "Organizer Name")]
        [Required]
        public int? OrganizerID { get; set; }
        public OrganizerModel Organizer { get; set; }
    }
}
