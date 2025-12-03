using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinc_Manegment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Doctor")]
    public class MedicationController : ControllerBase
    {
        private readonly IMedicationRepo _medicationRepo;
        public MedicationController(IMedicationRepo medicationRepo)
        {
            _medicationRepo = medicationRepo;
        }
        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> AddMedication(MedicationDTO medicationDTO)
        {
            var check = await _medicationRepo.checkUserByEmail(medicationDTO.PatientEmail);
            if (!check)
            {
                return BadRequest("User not found.");
            }
            await _medicationRepo.AddMedicen(medicationDTO);
            return Ok("Medication added successfully.");
        }
        [HttpGet]
        [Route("Get medication")]
        public async Task<IActionResult> GetMedicationsByPatientEmail(string patientEmail)
        {
            var check = await _medicationRepo.checkUserByEmail(patientEmail);
            if (!check)
            {
                return BadRequest("User not found.");
            }
            var medications = await _medicationRepo.GetMedicationsByPatientEmail(patientEmail);
            return Ok(medications);
        }
    }
}
