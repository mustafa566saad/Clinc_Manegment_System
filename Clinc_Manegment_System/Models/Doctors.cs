using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Clinc_Manegment_System.Models
{
    public class Doctors
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string? LastName { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        
        public string Email { get; set; }

        [ForeignKey("Department")]
        public string DepartmentName { get; set; }

        public Department? Department { get; set; }
        public ICollection<Appointments>? Appointments { get; set; }
    }
}
