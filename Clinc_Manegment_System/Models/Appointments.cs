using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinc_Manegment_System.Models
{
    public class Appointments
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public Pationts? Patient { get; set; }


        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }
        public Doctors? Doctor {  get; set; }

        public DateTime AppointmentDate { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; } = "Scheduled";
    }
}