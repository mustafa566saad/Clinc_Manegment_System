using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clinc_Manegment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles ="Admin")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDeptRepo deptRepo;

        public DepartmentController(IDeptRepo deptRepo)
        {
            this.deptRepo = deptRepo;
        }

        [Route("Add")]
        [HttpPost]
        public async Task<IActionResult> AddDeptAsync(DepartmentDTO DTO)
        {
            if (ModelState.IsValid) 
            {
                await deptRepo.AddDept(DTO);
                return Ok("Department added");
            }
            return BadRequest(ModelState);
        }

        [Route("Delete")]
        [HttpPost]
        public async Task<IActionResult> DeleteDeptAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return BadRequest("Department name is required.");

            var check= await deptRepo.checkDept(name);
            if (check)
            {
                await deptRepo.DeleteDept(name);
                return Ok("Department deleted");
            }
            return BadRequest("Dapertment not found");
        }
    }
}
