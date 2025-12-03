using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Clinc_Manegment_System.Repositories
{
    public class DeptRepo : IDeptRepo
    {
        private readonly ClincContext context;

        public DeptRepo(ClincContext context)
        {
            this.context = context;
        }

        public async Task AddDept(DepartmentDTO DTO)
        {
            var Dept = new Department
            {
                Name = DTO.Name,
                Description = DTO.Description
            };
            await context.Departments.AddAsync(Dept);
            await context.SaveChangesAsync();

        }
        public async Task<bool> checkDept(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return false;

            return await context.Departments.AnyAsync(e => e.Name == name);
        }
        public async Task DeleteDept(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return;

            var dept=  context.Departments.FirstOrDefault(e => e.Name == name);
            if (dept == null)
                return;
            context.Departments.Remove(dept);
            await context.SaveChangesAsync();
        }
    }

    public interface IDeptRepo
    {
        public Task DeleteDept(string name);
        public Task<bool> checkDept(string name);
        public  Task AddDept(DepartmentDTO DTO);
    }
}
