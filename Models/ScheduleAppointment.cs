using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ClientCMS.Models
{
    public class ScheduleAppointment
    {
        [Key]
        public int AppointmentID { get; set; }
        [Required]
        public int PatientID { get; set; }
        [Required]
        public string SpecializationReqired { get; set; }
        [Required]
        public string DoctorName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime AppointmentTimeFROM { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime AppointmentTimeTO { get; set; }

    }
    public enum SpecializationRequired
    {
                    General,
                   Orthopedics,
                   Pediatrics,
                   Gynacologist,
                    Radiologist,
                  GOphthomalogist,
                   Cardiologist
    }

}
