using System.ComponentModel.DataAnnotations;

namespace Clinc_Manegment_System.DTO
{
    public class AppointmentSubmit
    {
        [DataType(DataType.EmailAddress)]

        public string DoctorEmail { get; set; }
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
    }
}
