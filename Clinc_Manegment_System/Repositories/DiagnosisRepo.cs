using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Clinc_Manegment_System.Repositories
{
    public class DiagnosisRepo : IDiagnosisRepo
    {
        private readonly ClincContext context;

        public DiagnosisRepo(ClincContext context)
        {
            this.context = context;
        }
        public IEnumerable<Diagnosis> GetAllDiagnosis()
        {
            return context.Diagnoses.ToList();
        }
        public Diagnosis GetDiagnosisByEmail(string email)
        {
            var user = context.Pationts.FirstOrDefault(e => e.Email == email);
            return user.Diagnosis;
        }
        public async Task AddDiagnosis(DiagnosisDTO DTO)
        {
            var patient = await context.Pationts.FirstOrDefaultAsync(e => e.Email == DTO.PatientEmail);
            var doctor = await context.Doctors.FirstOrDefaultAsync(e => e.Email == DTO.DoctorEmail);

            var diagnosis = new Diagnosis
            {
                DoctorId = doctor.Id,
                PationtId = patient.Id,
                Description = DTO.Descraption,
                Date = DTO.Date
            };
            patient.DiagnosisId = diagnosis.Id;

            await context.Diagnoses.AddAsync(diagnosis);
            await context.SaveChangesAsync();
        }


        public bool checkPatient(string email)
        {
            return context.Pationts.Any(e => e.Email == email);
        }

        public bool checkDoctor(string email)
        {
            return context.Doctors.Any(e => e.Email == email);
        }

        public bool findLastDiagonsis(string patientEmail)
        {
            var item =  context.Diagnoses.FirstOrDefault(a => a.Pationt.Email == patientEmail);
            return item != null ? true : false;
        }
        
        public async Task Update(UpdateDiagnosisDTO DTO,Diagnosis item)
        {

            if (DTO.DoctorEmail != null)
            {
                var newDoc = await context.Doctors.FindAsync(DTO.DoctorEmail);
                item.DoctorId = newDoc.Id;
                item.Doctor = newDoc;
            }

            if (DTO.Description != null) item.Description = DTO.Description;
            if (DTO.Date != null) item.Date = (DateTime)DTO.Date;

            await context.SaveChangesAsync();
            
        }
            

    }
}
