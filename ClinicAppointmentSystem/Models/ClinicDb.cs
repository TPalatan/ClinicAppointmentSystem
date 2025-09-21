using System.ComponentModel.DataAnnotations;

namespace ClinicAppointmentSystem.Models
{
    public class ClinicDb
    {

        [Key]
        public string appointmentId { get; set; }

        public string patientName { get; set; } 
        public string department { get; set; }  

        public DateOnly AppointmentDate { get; set; }

    }
}
