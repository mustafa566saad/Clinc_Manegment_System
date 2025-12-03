using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;

namespace Clinc_Manegment_System.Repositories
{
    public interface IDiagnosisRepo
    {
        public IEnumerable<Diagnosis> GetAllDiagnosis();
        public Diagnosis GetDiagnosisByEmail(string id);
        public Task AddDiagnosis(DiagnosisDTO DTO);
        public Task Update(UpdateDiagnosisDTO dto,Diagnosis item);
        public bool checkPatient(string email);
        public bool checkDoctor(string email);
        public bool findLastDiagonsis(string patientEmail);



    }
}