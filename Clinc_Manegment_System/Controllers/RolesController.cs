using Clinc_Manegment_System.DTO;
using Clinc_Manegment_System.Models;
using Clinc_Manegment_System.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Linq;
using System.Threading.Tasks;

namespace Clinc_Manegment_System.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        public RoleManager<IdentityRole> RoleManager;
        private readonly IRolesRepo rolesRepo;
        private readonly UserManager<ApplicationUser> userManager;

        public RolesController(RoleManager<IdentityRole> roleManager, IRolesRepo rolesRepo,UserManager<ApplicationUser> userManager)
        {
            RoleManager = roleManager;
            this.rolesRepo = rolesRepo;
            this.userManager = userManager;
        }

        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(string roleName)
        {
            if (string.IsNullOrWhiteSpace(roleName)) return BadRequest("Role name cannot be empty.");

            IdentityRole Role = new IdentityRole();
            Role.Name = roleName;
            var result = await RoleManager.CreateAsync(Role);
            if (result.Succeeded)
                return Ok($"Role '{roleName}' created successfully.");
            else
                return BadRequest("Role creation failed. " + string.Join(", ", result.Errors.Select(e => e.Description)));
        }

        [HttpPost]
        [Route("ChangeUserRole")]
        public async Task<IActionResult> ChangeUserRole(ChangeRoleDTO DTO)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid input data.");

            var user = await userManager.FindByEmailAsync(DTO.UserEmail);
            if (user == null)
                return NotFound("User not found.");

            if (DTO.NewRole == "Doctor")
            {
                if (string.IsNullOrWhiteSpace(DTO.DoctorDepartment))
                    return BadRequest("Department shouldn't be empty");

                if (!rolesRepo.ifDeptFound(DTO.DoctorDepartment))
                    return BadRequest("Department not found");
            }

            var currentRoles = await userManager.GetRolesAsync(user);

            if (currentRoles.Contains(DTO.NewRole))
            {
                if (DTO.NewRole == "Doctor")
                {
                    await rolesRepo.AddToDoctorClass(DTO.UserEmail, DTO.DoctorDepartment);
                    await rolesRepo.removeFromPatientClass(DTO.UserEmail);
                }

                return Ok($"User '{user.UserName}' already in role '{DTO.NewRole}'.");
            }

            if (currentRoles.Any())
            {
                var removeResult = await userManager.RemoveFromRolesAsync(user, currentRoles);
                if (!removeResult.Succeeded)
                {
                    return BadRequest("Failed to remove user from old roles. " + string.Join(", ", removeResult.Errors.Select(e => e.Description)));
                }
            }

            var addResult = await userManager.AddToRoleAsync(user, DTO.NewRole);
            if (!addResult.Succeeded)
            {
                if (currentRoles.Any())
                {
                    await userManager.AddToRolesAsync(user, currentRoles);
                }

                return BadRequest("Failed to add user to new role. " + string.Join(", ", addResult.Errors.Select(e => e.Description)));
            }

            if (DTO.NewRole == "Doctor")
            {
                await rolesRepo.AddToDoctorClass(DTO.UserEmail, DTO.DoctorDepartment);
                await rolesRepo.removeFromPatientClass(DTO.UserEmail);
            }
            else if (DTO.NewRole == "Admin")
            {
                
                await rolesRepo.removeFromPatientClass(DTO.UserEmail);
            }

            return Ok($"User '{user.UserName}' role changed to '{DTO.NewRole}' successfully.");
        }
    }
}
