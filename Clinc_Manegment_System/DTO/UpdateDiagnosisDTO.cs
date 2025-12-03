using System.ComponentModel.DataAnnotations;

namespace Clinc_Manegment_System.DTO
{
    public class UpdateDiagnosisDTO
    {
        [DataType(DataType.EmailAddress)]

        public string PatientEmail { get; set; }
        public string? Description { get; set; }

        [DataType(DataType.EmailAddress)]

        public string? DoctorEmail { get; set; }
        public DateTime? Date { get; set; }
    }
}
