using System;
using System.ComponentModel.DataAnnotations;

namespace CSharpTest.Models
{
    public class AppointmentDTO
    {
        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }

        [Required]
        public string Reason { get; set; }

        public int DiseasId { get; set; }

        [Required]
        public int AppointmentTypeId { get; set; }

        public int PatientId { get; set; }

        [Required]
        public int DoctorId { get; set; }
    }
}
