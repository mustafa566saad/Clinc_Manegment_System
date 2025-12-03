using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinc_Manegment_System.Models
{
    public class Pationts
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public DateOnly? DateOfBirth { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }


        [ForeignKey("Diagnosis")]
        public string? DiagnosisId { get; set; }
        public Diagnosis? Diagnosis { get; set; }
        public ICollection<Appointments>? Appointments { get; set; }

    }
}
