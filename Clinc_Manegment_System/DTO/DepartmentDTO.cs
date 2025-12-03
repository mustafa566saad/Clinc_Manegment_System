using System.ComponentModel.DataAnnotations;

namespace Clinc_Manegment_System.DTO
{
    public class DepartmentDTO
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
