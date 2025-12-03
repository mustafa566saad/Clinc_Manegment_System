using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;

namespace Clinc_Manegment_System.Repositories
{
    public interface IAppointmentRepo
    {
        public Task BookAppointment(AppointmentSubmit submit);
        public List<Appointments> GetAppointmentsForPationts();
        public List<Appointments> GetAppointmentsForDoctor();
        public bool checkPatient(string email);
        public bool checkDoc(string email);



    }
}
