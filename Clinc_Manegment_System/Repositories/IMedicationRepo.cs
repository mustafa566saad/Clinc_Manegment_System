using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;

namespace Clinc_Manegment_System.Repositories
{
    public interface IMedicationRepo
    {
        public Task AddMedicen(MedicationDTO medicationDTO);
        public Task<bool> checkUserByEmail(string email);
        public Task<List<Medication>> GetMedicationsByPatientEmail(string patientId);

    }
}
