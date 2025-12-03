using System.ComponentModel.DataAnnotations;

namespace Clinc_Manegment_System.DTO
{
    public class ChangeRoleDTO
    {
        [DataType(DataType.EmailAddress)]

        public string UserEmail { get; set; }
        public string NewRole { get; set; }
        public string? DoctorDepartment { get; set; }
    }

}
