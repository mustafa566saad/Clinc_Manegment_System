using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinc_Manegment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Doctor")]

    public class DiagonsisController : ControllerBase
    {
        private readonly IDiagnosisRepo diagnosisRepo;

        public DiagonsisController(IDiagnosisRepo diagnosisRepo)
        {
            this.diagnosisRepo = diagnosisRepo;
        }

        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddDiagonsisAsync(DiagnosisDTO DTO)
        {
            if (ModelState.IsValid)
            {
                var docResult = diagnosisRepo.checkDoctor(DTO.DoctorEmail);
                if (!docResult) return BadRequest("Doctor email invalid");
                var patientRst = diagnosisRepo.checkPatient(DTO.PatientEmail);
                if (!patientRst) return BadRequest("Patient email invalid");

                await diagnosisRepo.AddDiagnosis(DTO);
                return Ok("Diagnosis Added");
            }

            return BadRequest(ModelState);
            
        }

        [HttpPost]
        [Route("Update")]
        public async Task<IActionResult> UpdateDiagnosisAsync(UpdateDiagnosisDTO DTO)
        {
            if (ModelState.IsValid)
            {
                var patientRst = diagnosisRepo.checkPatient(DTO.PatientEmail);
                if (!patientRst) return BadRequest("Patient email invalid");
                if (string.IsNullOrWhiteSpace(DTO.DoctorEmail))
                {
                    var docRst = diagnosisRepo.checkDoctor(DTO.DoctorEmail);
                    if(!docRst) return BadRequest("Doctor email invalid");
                }

                var FindDiagonsis = diagnosisRepo.findLastDiagonsis(DTO.PatientEmail);
                if (FindDiagonsis) return BadRequest("No diagonsis founded");

                var diagonsis = diagnosisRepo.GetDiagnosisByEmail(DTO.PatientEmail);
                await diagnosisRepo.Update(DTO, diagonsis);
                return Ok("diagnosis updated");
            }

            return BadRequest(ModelState);
        }

    }
}
