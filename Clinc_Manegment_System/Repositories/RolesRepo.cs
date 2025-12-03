using Clinc_Manegment_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Clinc_Manegment_System.Repositories
{
    public class RolesRepo : IRolesRepo
    {
        private readonly ClincContext context;

        public RolesRepo(ClincContext context)
        {
            this.context = context;
        }

        public IEnumerable<IdentityRole> GetAllRoles()
        {
            return context.Roles.ToList();
        }
        public IEnumerable<ApplicationUser> GetAllUsers()
        {
            return context.Users.ToList();

        }
        public ApplicationUser GetUser(string email)
        {
            ApplicationUser? user = GetAllUsers().FirstOrDefault(u => u.Email == email);
            return user;
        }
        public bool ifDeptFound(string deptname)
        {
            return context.Departments.Any(e => e.Name == deptname);
        }

        public async Task removeFromPatientClass(string email)
        {
            var user= await context.Pationts.FirstOrDefaultAsync(e => e.Email == email);
            context.Pationts.Remove(user);
            await context.SaveChangesAsync();
        }
        public async Task AddToDoctorClass(string email,string DeptName)
        {
            var user = await context.Pationts.FirstOrDefaultAsync(e => e.Email == email);
            var dept = await context.Departments.FirstOrDefaultAsync(e => e.Name == DeptName);
            var doc = new Doctors
            {
                FirstName = user.FirstName,
                LastName=user.LastName,
                Password=user.Password,
                PhoneNumber=user.PhoneNumber,
                Email=user.Email,
                DepartmentName=dept.Id

            };

            await context.Doctors.AddAsync(doc);
            await context.SaveChangesAsync();
        }

    }
}
