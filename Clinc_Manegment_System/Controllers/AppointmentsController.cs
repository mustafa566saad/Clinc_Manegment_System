using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinc_Manegment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentRepo appointmentRepo;

        public AppointmentsController(IAppointmentRepo appointmentRepo)
        {
            this.appointmentRepo = appointmentRepo;
        }

        [HttpPost]
        [Authorize(Roles = "Patient")]

        public async Task<IActionResult> BookAnAppointment(AppointmentSubmit submit)
        {
            if (ModelState.IsValid)
            {
                if (!appointmentRepo.checkDoc(submit.DoctorEmail)) return BadRequest("Doctor not found");
                await appointmentRepo.BookAppointment(submit);
                return Ok("Appointments created");
            }
            return BadRequest(ModelState);
        }

        [HttpGet]
        [Authorize(Roles = "Patient")]
        [Route("forpationt")]
        public IActionResult GetAppointmentForPationt()
        {
           var data= appointmentRepo.GetAppointmentsForPationts();
            return Ok(data); 
        }

        [HttpGet]
        [Authorize(Roles = "Doctor")]
        [Route("fordoctor")]

        public IActionResult GetAppointmentForDoctor()
        {
            var data = appointmentRepo.GetAppointmentsForDoctor();
            return Ok(data);
        }


    }
}
