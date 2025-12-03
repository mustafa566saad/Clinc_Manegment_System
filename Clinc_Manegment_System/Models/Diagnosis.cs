using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinc_Manegment_System.Models
{
    public class Diagnosis
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [ForeignKey("Pationt")]
        public string PationtId { get; set; }

        [ForeignKey("Doctor")]

        public string DoctorId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public Doctors? Doctor { get; set; }
        public Pationts? Pationt { get; set; }

    }
}
