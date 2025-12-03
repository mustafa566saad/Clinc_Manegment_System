using Clinc_Manegment_System.Models;
using Microsoft.AspNetCore.Identity;

namespace Clinc_Manegment_System.Repositories
{
    public interface IRolesRepo
    {
        public IEnumerable<IdentityRole> GetAllRoles();
        public ApplicationUser GetUser(string email);
        public  Task AddToDoctorClass(string email, string DeptName);
        public bool ifDeptFound(string deptname);
        public Task removeFromPatientClass(string email);

    }
}
