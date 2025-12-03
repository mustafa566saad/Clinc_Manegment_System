using System.ComponentModel.DataAnnotations;

namespace Clinc_Manegment_System.Models
{
    public class Department
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }

        public List<Doctors>? Doctors { get; set; }
    }
}
