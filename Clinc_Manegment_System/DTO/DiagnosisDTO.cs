using System.ComponentModel.DataAnnotations;

namespace Clinc_Manegment_System.DTO
{
    public class DiagnosisDTO
    {
        public string Descraption { get; set; }

        [DataType(DataType.EmailAddress)]

        public string PatientEmail { get; set; }

        [DataType(DataType.EmailAddress)]

        public string DoctorEmail { get; set; }
        public DateTime Date { get; set; }
    }
}
