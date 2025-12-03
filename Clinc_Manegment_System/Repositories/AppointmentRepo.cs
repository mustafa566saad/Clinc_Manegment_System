using Clinc_Manegment_System.DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; 
using System.Security.Claims;
using Clinc_Manegment_System.Models;
using System.Threading.Tasks;

namespace Clinc_Manegment_System.Repositories
{
    public class AppointmentRepo : IAppointmentRepo
    {
        private readonly ClincContext Context;
        private readonly IHttpContextAccessor httpContextAccessor; 

        public AppointmentRepo(ClincContext context, IHttpContextAccessor httpContextAccessor)
        {
            this.Context = context;
            this.httpContextAccessor = httpContextAccessor; 
        }

        public async Task BookAppointment(AppointmentSubmit submit)
        {
            var doc = Context.Doctors.FirstOrDefault(a => a.Email == submit.DoctorEmail);
            var Id = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var userid = Context.Users.Find(Id);
            var user = Context.Pationts.FirstOrDefault(e => e.Email == userid.Email);
            var appointment = new Appointments{
                AppointmentDate = submit.DateTime,
                Reason = submit.Description,
                Status = "Pending",
                DoctorId = doc.Id,
                PatientId = user.Id
            };

            await Context.Appointments.AddAsync(appointment);
            await Context.SaveChangesAsync();
        }

        public List<Appointments> GetAppointmentsForPationts()
        {
            var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var UserAppointment = Context.Appointments.Where(a => a.PatientId == userId).ToList().ToList();
            
            return UserAppointment;
        }

        public List<Appointments> GetAppointmentsForDoctor()
        {
            var userId = httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var DoctorAppointment = Context.Appointments.Where(a => a.DoctorId == userId).ToList().ToList();
            return DoctorAppointment;
        }

        public bool checkPatient(string email)
        {
            return Context.Pationts.Any(e => e.Email == email);
        }

        public bool checkDoc(string email)
        {
            return Context.Doctors.Any(e => e.Email == email);
        }
    }
}
