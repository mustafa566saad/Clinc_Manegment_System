using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Clinc_Manegment_System.Repositories
{
    public class MedicationRepo : IMedicationRepo
    {
        private readonly ClincContext _context;

        public MedicationRepo(ClincContext context)
        {
            _context = context;
        }

        public async Task AddMedicen(MedicationDTO medicationDTO)
        {
            var user=_context.Pationts.FirstOrDefault(u => u.Email == medicationDTO.PatientEmail);
            var medication = new Medication
            {
                Name = medicationDTO.Name,
                Duration = medicationDTO.Duration,
                PatientId = user.Id
            };
            _context.Medications.Add(medication);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> checkUserByEmail(string email)
        {
            return await _context.Pationts.AnyAsync(u => u.Email == email);
        }

        public async Task<List<Medication>> GetMedicationsByPatientEmail(string patientEmail)
        {
            return await _context.Medications
                .Where(m => m.Patient.Email == patientEmail)
                .ToListAsync();
        }
    }
}
