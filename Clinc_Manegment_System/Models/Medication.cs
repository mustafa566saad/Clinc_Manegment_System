using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinc_Manegment_System.Models
{
    public class Medication
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string Name { get; set; }
        public string? Duration { get; set; }

        [ForeignKey("Patient")]
        public string PatientId { get; set; }
        public Pationts Patient { get; set; }
    }
}
